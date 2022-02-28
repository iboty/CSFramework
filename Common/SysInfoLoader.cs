using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSFramework.Common.Data;
using CSFramework.Common.Helper;
using CSFramework.MVVM.Roles;
using SqlSugar;

namespace CSFramework.Common
{
    /// <summary>
    /// 框架信息加载器
    /// </summary>
    public  static class SysInfoLoader
    {
        public static string FileDir = $@"{AppDomain.CurrentDomain.BaseDirectory}Config";
        public static string FileName = "FrameworkInfo.xml";
        public static string FilePath = $"{FileDir}\\{FileName}";

        public static FrameworkInfo FrameworkInfo;

        /// <summary>
        /// 加载数据
        /// </summary>
        static SysInfoLoader()
        {
            Read();
        }

        public static void Read()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    FrameworkInfo = XmlHelper.ToObjectFromFile<FrameworkInfo>(FilePath);
                }
                else
                {
                    FrameworkInfo = new FrameworkInfo();
                    FrameworkInfo.SetDefaultValue();

                    Save();
                }
            }
            catch
            {
                FrameworkInfo.SetDefaultValue();
                FrameworkInfo = new FrameworkInfo();
            }
        }

        /// <summary>
        /// 保存当前信息
        /// </summary>
        public static void Save()
        {
            if (!Directory.Exists(FileDir)) Directory.CreateDirectory(FileDir);
            XmlHelper.SaveFileFromObject(FrameworkInfo, FilePath);
        }
    }
}
