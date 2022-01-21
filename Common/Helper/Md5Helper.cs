using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CSFramework.Common.Helper
{
    public class Md5Helper
    {
        public static string GetString(string valueString)
        {
            var md5 = new MD5CryptoServiceProvider();
            var fromData = Encoding.UTF8.GetBytes(valueString);
            var targetData = md5.ComputeHash(fromData).Reverse();
            var dm5Value = targetData.Select(t => t.ToString("x2")).Aggregate((t, s) => s += t);
            return dm5Value;
        }

        public static string GetStringFromFile(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var bufferSize = 1048576;
                var buff = new byte[bufferSize];
                var md5 = new MD5CryptoServiceProvider();
                md5.Initialize();
                long offset = 0;
                while (offset < fs.Length)
                {
                    long readSize = bufferSize;
                    if (offset + readSize > fs.Length)
                        readSize = fs.Length - offset;
                    fs.Read(buff, 0, Convert.ToInt32(readSize));
                    if (offset + readSize < fs.Length)
                        md5.TransformBlock(buff, 0, Convert.ToInt32(readSize), buff, 0);
                    else
                        md5.TransformFinalBlock(buff, 0, Convert.ToInt32(readSize));
                    offset += bufferSize;
                }

                if (offset >= fs.Length)
                {
                    fs.Close();
                    var result = md5.Hash;
                    md5.Clear();
                    var sb = new StringBuilder(32);
                    foreach (var t in result) sb.Append(t.ToString("x2"));
                    return sb.ToString();
                }

                fs.Close();
            }

            return null;
        }
    }
}