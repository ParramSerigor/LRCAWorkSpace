using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace LRCA.classes
{
    public static class Extensions
    {
		public static byte[] ToByteArray(this string str)
		{
			return System.Text.Encoding.ASCII.GetBytes(str);
		}
		public static string FromByteArray(this byte[] str)
		{
			return System.Text.Encoding.ASCII.GetString(str);
		}
		public static string ToRead(this Stream value)
        {
            var result = string.Empty;
            using (var reader = new StreamReader(value))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        public static byte[] ToReadBytes(this Stream stream, int length)
        {
            byte[] fileData = null;
            using (var binaryReader = new BinaryReader(stream))
            {
                fileData = binaryReader.ReadBytes(length);
            }

            return fileData;
        }
        public static string ToEncryptUrl(this string value)
        {
            //string companyId = HttpContext.Current.Session["CCompanyId"].ToString();
            //return ConfigurationManager.AppSettings["AWS:URL"] + companyId + "/" + value.Split('/').Last();
            return new CryptoJS().AES_encrypt(value, AppConstants.secretKey, AppConstants.initVec) + ".image";
        }
    }
}