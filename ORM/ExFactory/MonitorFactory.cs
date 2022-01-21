using System;
using CSFramework.ORM.DbMintor;
using CSFramework.ORM.Interface;
using SqlSugar;

namespace CSFramework.ORM.ExFactory
{
    public static class MonitorFactory
    {
        public static IDbMonitor CreateInstance(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Oracle:
                   // return new OralceMonitor();
                case DbType.SqlServer:
                    return new SqlServerMonitor();
            }
            throw new Exception($"数据类型{dbType}，不支持监控");
        }
    }
}
