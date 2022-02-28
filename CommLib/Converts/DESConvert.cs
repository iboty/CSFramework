using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CSFramework.CommLib.Converts
{
    public static class DesConvert
    {
        public static byte[] DesVi = {0x01, 0x03, 0x56, 0x01, 0x03, 0x56, 0x01, 0x03 };

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="desKey"></param>
        /// <returns></returns>
        public static string ToEncryptString(string inString, string desKey = "(^_^)OK")
        {
            var key = Encoding.UTF8.GetBytes(desKey); //定义字节数组，用来存储密钥   
            var data = Convert.FromBase64String(inString); //定义字节数组，用来存储要解密的字符串 

            using (var mStream = new MemoryStream())
            {
                var desc = new DESCryptoServiceProvider();

                using (var cStream = new CryptoStream(mStream, desc.CreateDecryptor(key, DesVi), CryptoStreamMode.Write))
                {
                    //向解密流中写入数据    
                    cStream.Write(data, 0, data.Length);
                    //释放解密流    
                    cStream.FlushFinalBlock(); 
                    return Convert.ToBase64String(mStream.ToArray());
                }
            }
        }
        /// <summary>
        /// 转换解密字符串
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="desKey"></param>
        /// <returns></returns>
        public static string ToDecryptString(string inString, string desKey = "(^_^)OK")
        {
            var key = Encoding.UTF8.GetBytes(desKey);
            var data = Convert.FromBase64String(inString);

            using (var mStream = new MemoryStream(data))
            {
                var desc = new DESCryptoServiceProvider();

                using (var cStream = new CryptoStream(mStream, desc.CreateDecryptor(key, DesVi), CryptoStreamMode.Read))
                {
                    using (var rStream = new StreamReader(cStream)) return rStream.ReadToEnd();
                }
            }
        }
    }
}
