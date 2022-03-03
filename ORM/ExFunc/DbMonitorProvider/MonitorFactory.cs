using System;
using CSFramework.ORM.Interface;
using SqlSugar;

namespace CSFramework.ORM.ExFunc.DbMonitorProvider
{
    internal static class MonitorFactory
    {
        public static IDbMonitor CreateInstance(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Oracle:
                   // return new OralceMonitor();
                case DbType.SqlServer:
                    return new SqlServerProvider();
            }
            throw new Exception($"数据类型{dbType}，不支持监控");
        }
    }
}
