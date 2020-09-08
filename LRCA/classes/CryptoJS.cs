using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace LRCA.classes
{
    public class CryptoJS
    {

        public String AES_decrypt(string encrypted, String secretKey, String initVec)
        {
           
           // encrypted = HttpUtility.UrlDecode(encrypted);
            byte[] encryptedBytes = Base64UrlDecode(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.BlockSize = 128; Not Required
            //aes.KeySize = 256; Not Required
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;
            aes.Key = Encoding.UTF8.GetBytes(secretKey);
            aes.IV = Encoding.UTF8.GetBytes(initVec);
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            crypto.Dispose();
            return System.Text.ASCIIEncoding.ASCII.GetString(secret);
        }

        public String AES_encrypt(string plainText, String secretKey, String initVec)
        {
            byte[] encryptedBytes = Encoding.UTF8.GetBytes(plainText);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //aes.BlockSize = 128; Not Required
            //aes.KeySize = 256; Not Required
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.ISO10126;
            aes.Key = Encoding.UTF8.GetBytes(secretKey);
            aes.IV = Encoding.UTF8.GetBytes(initVec);
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] secret = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            crypto.Dispose();
           
            return Base64UrlEncode(secret.ToArray());
            
        }

        public static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes).Replace("=", "").Replace('+', '-').Replace('/', '_');
        }

        public static byte[] Base64UrlDecode(string s)
        {
            s = s.Trim();
            s = s.Replace('-', '+').Replace('_', '/');
            string padding = new String('=', 3 - (s.Length + 3) % 4);
            s += padding;
            return Convert.FromBase64String(s);
        }
    }
}