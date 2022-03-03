using System;
using SqlSugar;

namespace CSFramework.ORM.Data
{
    /// <summary>
    ///  数据库更新实体对象记录
    /// </summary>
    [SugarTable("db_update_rec", "数据库更新日志")]
    public  class DbUpdateRecordEntity
    {
        [SugarColumn(ColumnDataType = "varchar(20)", ColumnDescription = "实体对象更新版本", IsPrimaryKey = true)]
        public string Version { get; set; } = "0.0.0";

        [SugarColumn( ColumnDescription = "更新时间")]
        public DateTime UpdateTime { get; set; }

        [SugarColumn(ColumnDataType = "varchar(512)", ColumnDescription = "更新描述")]
        public string Remark { get; set; }
    }
}
