using System.Xml.Serialization;
using SqlSugar;

namespace CSFramework.Common.Data
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class DbConnInfo
    {
        /// <summary>
        /// 连接名称
        /// </summary>
        [XmlAttribute]
        public string ConnName { get; set; }
        /// <summary>
        ///  数据连接Ip
        /// </summary>
        [XmlAttribute]
        public string ServerIp { get; set; }
        /// <summary>
        /// 连接数据库端口
        /// </summary>
        [XmlAttribute]
        public string Port { get; set;}
        /// <summary>
        /// 数据库名字
        /// </summary>
        [XmlAttribute]
        public string DbName { get; set; }
        /// <summary>
        /// 登陆名
        /// </summary>
        [XmlAttribute]
        public string User { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        [XmlAttribute]
        public string Password { get; set; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        [XmlAttribute]
        public DbType DbType {get; set; }
        /// <summary>
        /// 数据库文件路径
        /// </summary>
        [XmlAttribute]
        public string DbFilePath { get; set; }

        [XmlAttribute]
        public bool IsDefault { get; set; }
    }
}
