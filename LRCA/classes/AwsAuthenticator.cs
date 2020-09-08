using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LRCA.classes
{
    public class AwsAuthenticator : RestSharp.Authenticators.IAuthenticator
    {
        public string AccessKeyId { get; }
        public string AccessKeySecret { get; }
        public string Region { get; }

        public AwsAuthenticator(string accessKeyId, string accessKeySecret, string region)
        {
            AccessKeyId = accessKeyId;
            AccessKeySecret = accessKeySecret;
            Region = region;
        }

        private static HashSet<string> ignoredHeaders = new HashSet<string>() {
            "authorization",
            "content-length",
            "content-type",
            "user-agent"
        };

        public void Authenticate(RestSharp.IRestClient client, RestSharp.IRestRequest request)
        {
            DateTime signingDate = DateTime.UtcNow;
            SetContentMd5(request);
            SetContentSha256(request);
            SetHostHeader(request, client);
            SetDateHeader(request, signingDate);
            SortedDictionary<string, string> headersToSign = GetHeadersToSign(request);
            string signedHeaders = GetSignedHeaders(headersToSign);
            string canonicalRequest = GetCanonicalRequest(client, request, headersToSign);
            byte[] canonicalRequestBytes = System.Text.Encoding.UTF8.GetBytes(canonicalRequest);
            string canonicalRequestHash = BytesToHex(ComputeSha256(canonicalRequestBytes));
            string stringToSign = GetStringToSign(Region, signingDate, canonicalRequestHash);
            byte[] signingKey = GenerateSigningKey(Region, signingDate);

            byte[] stringToSignBytes = System.Text.Encoding.UTF8.GetBytes(stringToSign);

            byte[] signatureBytes = SignHmac(signingKey, stringToSignBytes);

            string signature = BytesToHex(signatureBytes);

            string authorization = GetAuthorizationHeader(signedHeaders, signature, signingDate, Region);
            request.AddHeader("Authorization", authorization);

        }

        public string GetCredentialString(DateTime signingDate, string region)
        {
            return AccessKeyId + "/" + GetScope(region, signingDate);
        }

        private string GetAuthorizationHeader(string signedHeaders, string signature, DateTime signingDate, string region)
        {
            return "AWS4-HMAC-SHA256 Credential=" + this.AccessKeyId + "/" + GetScope(region, signingDate) +
                ", SignedHeaders=" + signedHeaders + ", Signature=" + signature;
        }

        private string GetSignedHeaders(SortedDictionary<string, string> headersToSign)
        {
            return string.Join(";", headersToSign.Keys);
        }

        private byte[] GenerateSigningKey(string region, DateTime signingDate)
        {
            byte[] formattedDateBytes = System.Text.Encoding.UTF8.GetBytes(signingDate.ToString("yyyMMdd"));
            byte[] formattedKeyBytes = System.Text.Encoding.UTF8.GetBytes("AWS4" + this.AccessKeySecret);
            byte[] dateKey = SignHmac(formattedKeyBytes, formattedDateBytes);

            byte[] regionBytes = System.Text.Encoding.UTF8.GetBytes(region);
            byte[] dateRegionKey = SignHmac(dateKey, regionBytes);

            byte[] serviceBytes = System.Text.Encoding.UTF8.GetBytes("s3");
            byte[] dateRegionServiceKey = SignHmac(dateRegionKey, serviceBytes);

            byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes("aws4_request");
            return SignHmac(dateRegionServiceKey, requestBytes);
        }

        private byte[] SignHmac(byte[] key, byte[] content)
        {
            HMACSHA256 hmac = new HMACSHA256(key);
            hmac.Initialize();
            return hmac.ComputeHash(content);
        }

        private string GetStringToSign(string region, DateTime signingDate, string canonicalRequestHash)
        {
            return "AWS4-HMAC-SHA256\n" +
                signingDate.ToString("yyyyMMddTHHmmssZ") + "\n" +
                GetScope(region, signingDate) + "\n" +
                canonicalRequestHash;
        }

        private string GetScope(string region, DateTime signingDate)
        {
            string formattedDate = signingDate.ToString("yyyyMMdd");
            return formattedDate + "/" + region + "/s3/aws4_request";
        }

        private byte[] ComputeSha256(byte[] body)
        {

            SHA256 sha256 = SHA256.Create();
            return sha256.ComputeHash(body);
        }

        private string BytesToHex(byte[] checkSum)
        {
            return BitConverter.ToString(checkSum).Replace("-", string.Empty).ToLower();
        }

        public string PresignPostSignature(string region, DateTime signingDate, string policyBase64)
        {
            byte[] signingKey = this.GenerateSigningKey(region, signingDate);
            byte[] stringToSignBytes = System.Text.Encoding.UTF8.GetBytes(policyBase64);

            byte[] signatureBytes = SignHmac(signingKey, stringToSignBytes);
            string signature = BytesToHex(signatureBytes);

            return signature;
        }

        public string PresignURL(RestSharp.IRestClient client, RestSharp.IRestRequest request, int expires)
        {
            DateTime signingDate = DateTime.UtcNow;
            string requestQuery = "";
            string path = request.Resource;

            requestQuery = "X-Amz-Algorithm=AWS4-HMAC-SHA256&";
            requestQuery += "X-Amz-Credential="
                + this.AccessKeyId
                + Uri.EscapeDataString("/" + GetScope(Region, signingDate))
                + "&";
            requestQuery += "X-Amz-Date="
                + signingDate.ToString("yyyyMMddTHHmmssZ")
                + "&";
            requestQuery += "X-Amz-Expires="
                + expires
                + "&";
            requestQuery += "X-Amz-SignedHeaders=host";

            string canonicalRequest = GetPresignCanonicalRequest(client, request, requestQuery);
            byte[] canonicalRequestBytes = System.Text.Encoding.UTF8.GetBytes(canonicalRequest);
            string canonicalRequestHash = BytesToHex(ComputeSha256(canonicalRequestBytes));
            string stringToSign = GetStringToSign(Region, signingDate, canonicalRequestHash);
            byte[] signingKey = GenerateSigningKey(Region, signingDate);
            byte[] stringToSignBytes = System.Text.Encoding.UTF8.GetBytes(stringToSign);
            byte[] signatureBytes = SignHmac(signingKey, stringToSignBytes);
            string signature = BytesToHex(signatureBytes);

            // Return presigned url.
            return client.BaseUrl + path + "?" + requestQuery + "&X-Amz-Signature=" + signature;
        }

        private string GetPresignCanonicalRequest(RestSharp.IRestClient client, RestSharp.IRestRequest request, string requestQuery)
        {
            LinkedList<string> canonicalStringList = new LinkedList<string>();
            canonicalStringList.AddLast(request.Method.ToString());

            string path = request.Resource;
            if (!path.StartsWith("/"))
            {
                path = "/" + path;
            }
            canonicalStringList.AddLast(path);
            canonicalStringList.AddLast(requestQuery);
            canonicalStringList.AddLast("host:" + client.BaseUrl.Host);
            canonicalStringList.AddLast("");
            canonicalStringList.AddLast("host");
            canonicalStringList.AddLast("UNSIGNED-PAYLOAD");

            return string.Join("\n", canonicalStringList);
        }

        private string GetCanonicalRequest(RestSharp.IRestClient client, RestSharp.IRestRequest request,
            SortedDictionary<string, string> headersToSign)
        {
            LinkedList<string> canonicalStringList = new LinkedList<string>();
            canonicalStringList.AddLast(request.Method.ToString());

            if (!string.IsNullOrWhiteSpace(request.Resource))
            {
                string[] path = request.Resource.Split(new char[] { '?' }, 2);
                if (!path[0].StartsWith("/"))
                {
                    path[0] = "/" + path[0];
                }
                canonicalStringList.AddLast(path[0]);

                string query = "";
                if (path.Length == 2)
                {
                    var parameterString = path[1];
                    var parameterList = parameterString.Split('&');
                    SortedSet<string> sortedQueries = new SortedSet<string>();
                    foreach (string individualParameterString in parameterList)
                    {
                        if (individualParameterString.Contains('='))
                        {
                            string[] splitQuery = individualParameterString.Split(new char[] { '=' }, 2);
                            sortedQueries.Add(splitQuery[0] + "=" + splitQuery[1]);
                        }
                        else
                        {
                            sortedQueries.Add(individualParameterString + "=");
                        }
                    }
                    query = string.Join("&", sortedQueries);
                }
                canonicalStringList.AddLast(query); 
            }

            foreach (string header in headersToSign.Keys)
            {
                canonicalStringList.AddLast(header + ":" + headersToSign[header]);
            }
            canonicalStringList.AddLast("");
            canonicalStringList.AddLast(string.Join(";", headersToSign.Keys));
            if (headersToSign.Keys.Contains("x-amz-content-sha256"))
            {
                canonicalStringList.AddLast(headersToSign["x-amz-content-sha256"]);
            }
            else
            {
                canonicalStringList.AddLast("e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
            }

            return string.Join("\n", canonicalStringList);
        }

        private SortedDictionary<string, string> GetHeadersToSign(RestSharp.IRestRequest request)
        {
            var headers = request.Parameters.Where(p => p.Type.Equals(RestSharp.ParameterType.HttpHeader)).ToList();

            SortedDictionary<string, string> sortedHeaders = new SortedDictionary<string, string>();
            foreach (var header in headers)
            {
                string headerName = header.Name.ToLower();
                string headerValue = header.Value.ToString();
                if (!ignoredHeaders.Contains(headerName))
                {
                    sortedHeaders.Add(headerName, headerValue);
                }
            }
            return sortedHeaders;
        }

        private void SetDateHeader(RestSharp.IRestRequest request, DateTime signingDate)
        {
            request.AddHeader("x-amz-date", signingDate.ToString("yyyyMMddTHHmmssZ"));
        }

        private void SetHostHeader(RestSharp.IRestRequest request, RestSharp.IRestClient client)
        {
            request.AddHeader("Host", client.BaseUrl.Host + (client.BaseUrl.Port != 80 ? ":" + client.BaseUrl.Port : string.Empty));
        }

        private void SetContentSha256(RestSharp.IRestRequest request)
        {
            if (request.Method == RestSharp.Method.PUT || request.Method.Equals(RestSharp.Method.POST))
            {
                var bodyParameter = request.Parameters.Where(p => p.Type.Equals(RestSharp.ParameterType.RequestBody)).FirstOrDefault();
                if (bodyParameter == null)
                {
                    request.AddHeader("x-amz-content-sha256", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
                    return;
                }
                byte[] body = null;
                if (bodyParameter.Value is string)
                {
                    body = System.Text.Encoding.UTF8.GetBytes(bodyParameter.Value as string);
                }
                if (bodyParameter.Value is byte[])
                {
                    body = bodyParameter.Value as byte[];
                }
                if (body == null)
                {
                    body = new byte[0];
                }
                SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
                byte[] hash = sha256.ComputeHash(body);
                string hex = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                request.AddHeader("x-amz-content-sha256", hex);
            }
            else
            {
                request.AddHeader("x-amz-content-sha256", "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
            }
        }

        private void SetContentMd5(RestSharp.IRestRequest request)
        {
            if (request.Method == RestSharp.Method.PUT || request.Method.Equals(RestSharp.Method.POST))
            {
                var bodyParameter = request.Parameters.Where(p => p.Type.Equals(RestSharp.ParameterType.RequestBody)).FirstOrDefault();
                if (bodyParameter == null)
                {
                    return;
                }
                byte[] body = null;
                if (bodyParameter.Value is string)
                {
                    body = System.Text.Encoding.UTF8.GetBytes(bodyParameter.Value as string);
                }
                if (bodyParameter.Value is byte[])
                {
                    body = bodyParameter.Value as byte[];
                }
                if (body == null)
                {
                    body = new byte[0];
                }
                MD5 md5 = MD5.Create();
                byte[] hash = md5.ComputeHash(body);

                string base64 = Convert.ToBase64String(hash);
                request.AddHeader("Content-MD5", base64);
            }
        }
    }
}