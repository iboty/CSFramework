using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace CSFramework.ORM.Data
{
    [SugarTable("db_ver_info", "数据库版本信息")]
    public  class DbVerInfo
    {
        [SugarColumn(ColumnDataType = "varchar(20)", ColumnDescription = "版本", IsPrimaryKey = true)]
        public string Version { get; set; } = "0.0.0.0";

        [SugarColumn( ColumnDescription = "更新时间")]
        public DateTime UpdateTime { get; set; }
    }
}
