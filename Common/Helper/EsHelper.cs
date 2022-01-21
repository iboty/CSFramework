using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CSFramework.Common.Helper
{
    public  class EsHelper
    {

        private static readonly byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        //公钥
        private static readonly string CommonKey = "(a^_^ha)";
        /// <summary>
        /// 字符串加密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encryption(string text)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(CommonKey.Substring(0, 8));
                var rgbIv = Keys;
                var inputByteArray = Encoding.UTF8.GetBytes(text);
                var dCsp = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dCsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return text;
            }
        }

        /// <summary>
        /// 数据加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Encryption(byte[] data)
        {

            MemoryStream mStream = null;
            CryptoStream cStream = null;
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(CommonKey.Substring(0, 8));
                var rgbIv = Keys;

                var dCsp = new DESCryptoServiceProvider();
                mStream = new MemoryStream();
                cStream = new CryptoStream(mStream, dCsp.CreateEncryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();
                return mStream.ToArray();
            }
            finally
            {
                if (mStream != null) mStream.Close();
                if(cStream != null)cStream.Close();
            }
        }


        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decryption(string text)
        {
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(CommonKey);
                var rgbIv = Keys;
                var inputByteArray = Convert.FromBase64String(text);
                var dcsp = new DESCryptoServiceProvider();
                var mStream = new MemoryStream();
                var cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return text;
            }
        }


        /// <summary>
        /// 字符串解密
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] Decryption(byte[] data)
        {
            MemoryStream mStream = null;
            CryptoStream cStream = null;
            try
            {
                var rgbKey = Encoding.UTF8.GetBytes(CommonKey);
                var rgbIv = Keys;
                
                var dcsp = new DESCryptoServiceProvider();
                 mStream = new MemoryStream();
                 cStream = new CryptoStream(mStream, dcsp.CreateDecryptor(rgbKey, rgbIv), CryptoStreamMode.Write);
                 cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();
                return mStream.ToArray();
            }
            finally 
            {
                if (mStream != null) mStream.Close();
                if (cStream != null) cStream.Close();
            }
        }

  
    }
}
