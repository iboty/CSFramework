using System.Collections.Generic;
using SqlSugar;

namespace CSFramework.Common.Data
{
    public class FrameworkInfo
    {
        public void SetDefaultValue()
        {
            //默认值
            FactoryInfos = new List<FactoryInfo>
            {
                new FactoryInfo { Name = "默认业务工厂", LayerType = LayerType.Bll, IsDefault = true, LibFileRule = "*.Bll.dll"},
                new FactoryInfo { Name = "默认数据工厂",LayerType = LayerType.Dal,  IsDefault = true, LibFileRule = "*.Dal.dll" }
            };

            DbConnInfos = new List<DbConnInfo>
            {
                new DbConnInfo{ ConnName = "默认数据库",ServerIp = "127.0.0.1", Port = "3306", DbName = "DbInstance", DbType = DbType.MySql, User = "root", Password = "123456", IsDefault = true},
            };
        }

        /// <summary>
        /// 工厂信息集合
        /// </summary>
        public  List<FactoryInfo> FactoryInfos { get;  set; }
        /// <summary>
        /// 连接数据库信息集合
        /// </summary>
        public  List<DbConnInfo> DbConnInfos { get; set; }

        /// <summary>
        /// 系统日志信息
        /// </summary>
        public SysLogInfo SysLogInfo { get; set;}

    }
}
