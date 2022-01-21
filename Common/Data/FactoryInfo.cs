using System.Xml.Serialization;

namespace CSFramework.Common.Data
{
    public class FactoryInfo
    {
        /// <summary>
        /// 工厂实例名称
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }
        /// <summary>
        /// 工厂类型
        /// </summary>
        [XmlAttribute]
        public FactoryType FactoryType { get; set; }

        /// <summary>
        /// 分层类型
        /// </summary>
        [XmlAttribute]
        public LayerType LayerType { get; set; }

        /// <summary>
        /// 工厂地址 MEF-指容器文件目录地址，WCF-表示服务地址
        /// </summary>
        [XmlAttribute]
        public string BasePath { get; set; }
        /// <summary>
        /// 是否默认
        /// </summary>
        [XmlAttribute]
        public bool IsDefault { get; set; }
        /// <summary>
        /// MEF 文件的规则
        /// </summary>
        [XmlAttribute]
        public string LibFileRule { get; set; }
    }
}
