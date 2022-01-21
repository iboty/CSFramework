using System.Collections.Generic;
using SqlSugar;

namespace CSFramework.Common.Data
{
    public class FrameworkInfo
    {
        public void SetDefaultValue()
        {
            //默认值
            FactoryInfoList = new List<FactoryInfo>
            {
                new FactoryInfo { Name = "默认业务工厂", LayerType = LayerType.Bll, IsDefault = true, LibFileRule = "*.Bll.dll"},
                new FactoryInfo { Name = "默认数据工厂",LayerType = LayerType.Dal,  IsDefault = true, LibFileRule = "*.Dal.dll" }
            };

            DbInfoList = new List<DbInfo>
            {
                new DbInfo{ ConnName = "默认数据库",ServerIp = "127.0.0.1", Port = "3306", DbName = "DbInstance", DbType = DbType.MySql, User = "root", Password = "123456", IsDefault = true},
            };
        }

        /// <summary>
        /// 工厂信息集合
        /// </summary>
        public  List<FactoryInfo> FactoryInfoList { get;  set; }
        /// <summary>
        /// 数据库信息集合
        /// </summary>
        public  List<DbInfo> DbInfoList { get; set; }


        


    }
}
