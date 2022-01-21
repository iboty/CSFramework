using System;
using CSFramework.ORM.Data;
using CSFramework.ORM.ExFactory;
using SqlSugar;

namespace CSFramework.ORM.ExFunc
{
    public static class DbMonitorEx
    {
        public static void RunMonitor<T>(ISugarQueryable<T> query, Action<object, DbNotifyEventArgs> handle)
        {
            var instance = MonitorFactory.CreateInstance(query.Context.CurrentConnectionConfig.DbType);
            instance.Monitor(query, handle);
        }

        public static void MonitorStart(SqlSugarClient client)
        {
            var instance = MonitorFactory.CreateInstance(client.CurrentConnectionConfig.DbType);
            instance.MonitorStart(client);
        }

        public static void MonitorStop(SqlSugarClient client)
        {
            var instance = MonitorFactory.CreateInstance(client.CurrentConnectionConfig.DbType);
            instance.MonitorStop(client);
        }


    }
}
