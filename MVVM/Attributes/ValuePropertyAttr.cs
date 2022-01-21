using System;

namespace CSFramework.MVVM.Attributes
{
    public class ValuePropertyAttr : Attribute
    {
        /// <summary>
        ///  自动创建Guid
        /// </summary>
        public bool AutoGuid { get; set; }
        /// <summary>
        /// 映射对应实体属性名
        /// </summary>
        public string EntityPropertyName { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public object DefaultValue { get; set; }
        /// <summary>
        ///  实体转换忽视
        /// </summary>
        public bool Ignore { get; set; }
        /// <summary>
        /// 属性的描述
        /// </summary>
        public string Desc { get; set; }

        public bool BackupIgnore { get; set; }
    }
}
