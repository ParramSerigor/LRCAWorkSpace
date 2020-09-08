using System;
using Amazon.S3.Model;
using Amazon.S3;
using System.IO;
using Amazon.S3.Transfer;
using System.Security.Cryptography;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;
using System.Threading.Tasks;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using LRCA.classes.Entity;
using LRCA.classes.DAL;
using System.Diagnostics;
using System.Web;

namespace LRCA.classes
{
    public class S3 : IS3
    {
        public bool sendMyFileToS3(System.IO.Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            IS3 s3 = this;
            return string.IsNullOrEmpty(s3.TryAddToAmazonBucket(localFilePath, fileNameInS3, subDirectoryInBucket));
        }
        public static bool sendMyFileToS3_old(System.IO.Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            bool IsComplete = true;
            #region Creating a new S3 Sub-Folder under AWS LRCA Folder
            //string NewSubFolderName = CompName.ToString().Replace(" ", "").Trim() + CompId;
            string strAWSAccessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
            string strAWSSecretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];

            AmazonS3Config config = new AmazonS3Config();
            config.ServiceURL = "testsourcespoon.s3.amazonaws.com";
            config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;

            AmazonS3Client s3Client = new AmazonS3Client(
                    strAWSAccessKey,
                    strAWSSecretKey,
                    config
                    );


            using (IAmazonS3 s3ClientInterface = s3Client)
            {
                try
                {
                    // create a TransferUtility instance passing it the IAmazonS3 created in the first step
                    TransferUtility utility = new TransferUtility(s3Client);
                    // making a TransferUtilityUploadRequest instance
                    TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

                    if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
                    {
                        request.BucketName = bucketName; //no subdirectory just bucket name
                    }
                    else
                    {   // subdirectory and bucket name
                        request.BucketName = bucketName + @"/" + subDirectoryInBucket;
                    }

                    request.Key = fileNameInS3; //file name up in S3
                    //request.FilePath = localFilePath; //local file name
                    request.InputStream = localFilePath;
                    request.CannedACL = S3CannedACL.PublicReadWrite;
                    utility.Upload(request);


                }
                catch (AmazonS3Exception ex)
                {
                    IsComplete = false;
                    // GlobalMethods.ReportBug("LRCA", DateTime.Now.ToShortDateString(), ex.Message + Environment.NewLine + "STACKTRACE:" + Environment.NewLine + ex.StackTrace, "///S3.cs - sendMyFileToS3(System.IO.Stream localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)");
                }
            }
            return IsComplete;
            #endregion
        }
        public bool CreateSubDirectory(string Subdirectory)
        {
            bool IsComplete = true;
            #region Creating a new S3 Sub-Folder under AWS LRCA Folder
            string NewSubFolderName = Subdirectory;
            
                try
                {
                    PutObjectRequest folderRequest = new PutObjectRequest();
                    String delimiter = "/";
                    folderRequest.BucketName = "testsourcespoon";
                    String folderKey = string.Concat(NewSubFolderName, delimiter);
                    folderRequest.Key = folderKey;
                    folderRequest.InputStream = new MemoryStream(new byte[0]);
                
                    AwsProfile.SoleInstance.PutObject(folderRequest);
                }
                catch (AmazonS3Exception ex)
                {
                    IsComplete = false;
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
           
            return IsComplete;
            #endregion
        }
        public bool DeleteFile(string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {
            bool IsComplete = true;
            #region Creating a new S3 Sub-Folder under AWS LRCA Folder
            string strAWSAccessKey = System.Configuration.ConfigurationManager.AppSettings["AWSAccessKey"];
            string strAWSSecretKey = System.Configuration.ConfigurationManager.AppSettings["AWSSecretKey"];

            AmazonS3Config config = new AmazonS3Config();
            //config.ServiceURL = "sourcespoon.s3.amazonaws.com";
            config.ServiceURL = "testsourcespoon.s3.amazonaws.com";
            config.RegionEndpoint = Amazon.RegionEndpoint.USEast1;

            AmazonS3Client s3Client = new AmazonS3Client(
                    strAWSAccessKey,
                    strAWSSecretKey,
                    config
                    );


            using (IAmazonS3 s3ClientInterface = s3Client)
            {
                try
                {
                    DeleteObjectRequest request = new DeleteObjectRequest();
                    request.BucketName = bucketName;
                    request.Key = subDirectoryInBucket + "/" + fileNameInS3;
                    s3Client.DeleteObject(request);

                }
                catch (AmazonS3Exception ex)
                {
                    IsComplete = false;
                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
            }
            return IsComplete;
            #endregion
        }

        public bool DeleteBucket(string bucketName)
        {
            bool IsComplete = true;
            #region Creating a new S3 Sub-Folder under AWS LRCA Folder
            
           
                try
                {
                    DeleteObjectRequest request = new DeleteObjectRequest();
                    request.BucketName = bucketName;
                //s3Client.DeleteObject(request);
                AwsProfile.SoleInstance.DeleteObject(request);

            }
                catch (AmazonS3Exception ex)
                {
                    IsComplete = false;

                    ErrorHandler.ErrorLogging(ex, false);
                    ErrorHandler.ReadError();
                }
            
            return IsComplete;
            #endregion
        }

        string IS3.TryAddToAmazonBucket(Stream stream, string fileName, string subDirectory)
        {
            var result ="uploading";
            try
            {
                PutObjectRequest request = new PutObjectRequest();
                if (string.IsNullOrWhiteSpace(subDirectory) && !ReferenceEquals(null, System.Web.HttpContext.Current))
                {
                    var company = System.Web.HttpContext.Current.Session["CCompanyId"];
                    if (!ReferenceEquals(null, company))
                    {
                        subDirectory = company.ToString();
                    }
                }
                request.BucketName = ConfigurationManager.AppSettings["awsBucketName"] + @"/" + subDirectory;
                request.Key = fileName;
                request.InputStream = stream;
                request.CannedACL = S3CannedACL.PublicReadWrite;
                request.Grants = new List<S3Grant>()
                {
                    new S3Grant()
                    {
                         Grantee= new S3Grantee()
                         {
                             CanonicalUser = "nbroadcast",
                             DisplayName = "nbroadcast"
                         },
                         Permission = new S3Permission("open/download")
                    }
                };
                AwsProfile.SoleInstance.PutObject(request);
                result = string.Empty;
            }
            catch (AmazonS3Exception ex)
            {
                result = ex.Message;
                Debug.WriteLine("S3: " + ex.Message);
            }
            catch (Exception ex)
            {
                result = ex.Message;
                Debug.WriteLine("S3: " + ex.Message);
            }


            return result;
        }

        string IS3.TryDelete(string id)
        {
            var result = string.Empty;
            var value = id.Split('/').Last();
          
            result = Delete(value, string.Empty);

            return result;
        }

        private static string Delete(string value, string subFolder)
        {
            var result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(subFolder))
                {
                    subFolder = HttpContext.Current.Session["CCompanyId"].ToString();
                }
                DeleteObjectRequest request = new DeleteObjectRequest();
                request.BucketName = ConfigurationManager.AppSettings["awsBucketName"] + @"/" + subFolder;
                request.Key = value;
                AwsProfile.SoleInstance.DeleteObject(request);
                result = "deleted succesfully!";
            }
            catch (AmazonS3Exception ex)
            {
                result = ex.Message;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        bool IS3.TryDelete(string id, string subFolder)
        {
            return Delete(id, subFolder).Equals("deleted succesfully!");
        }

        List<clsImageRepository> IS3.TryGetAllImagesAsync(string startAfter)
        {
            var result = new List<clsImageRepository>();
            var companyId = System.Web.HttpContext.Current.Session["CCompanyId"];
            if (!ReferenceEquals(null, companyId))
            {
                ListObjectsV2Request request = new ListObjectsV2Request();
                request.BucketName = ConfigurationManager.AppSettings["awsBucketName"];
                request.Prefix = companyId.ToString();
                request.MaxKeys = 10;
                if (!string.IsNullOrWhiteSpace(startAfter))
                {
                    request.StartAfter = startAfter;
                }
                result = (from s in AwsProfile.SoleInstance.ListObjectsV2(request).S3Objects.AsEnumerable()
                          select new clsImageRepository
                          {
                              URL = s.Key.ToEncryptUrl()
                          }).ToList();

            }
            return result;
        }
    }
}