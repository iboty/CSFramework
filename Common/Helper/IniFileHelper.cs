using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace CSFramework.Common.Helper
{
    public static class IniFileHelper
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary> 
        /// 写入INI文件 
        /// </summary> 
        /// <param name="section">项目名称(如 [TypeName] )</param> 
        /// <param name="key">键</param> 
        /// <param name="value">值</param>
        /// <param name="iniPath">ini文件路径</param> 
        public static void IniWriteValue(string section, string key, string value, string iniPath)
        {
            WritePrivateProfileString(section, key, value, iniPath);
        }

        /// <summary> 
        /// 读出INI文件 
        /// </summary> 
        /// <param name="section">项目名称(如 [TypeName] )</param> 
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <param name="iniPath">ini文件路径</param> 
        public static string IniReadValue(string section, string key, string defaultValue, string iniPath)
        {
            StringBuilder temp = new StringBuilder(500);
            GetPrivateProfileString(section, key, defaultValue, temp, 500, iniPath);
            return temp.ToString();
        }

    }
}
