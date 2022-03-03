using System.Xml.Serialization;
using CSFramework.MVVM.Data;

namespace CSFramework.Common.Data
{
  
    /// <summary>
    ///系统日志对象
    /// </summary>
    public class SysLogInfo
    {
        /// <summary>
        ///  消息等级过滤
        /// </summary>
        [XmlAttribute]
        public MsgLevel MsgLevel { get; set; } = MsgLevel.Info | MsgLevel.Error | MsgLevel.Warn;

        /// <summary>
        /// 目标文件夹路径
        /// </summary>
        [XmlAttribute]
        public string DstDirPath { get; set; } = ".\\SysLog";

    }
}
