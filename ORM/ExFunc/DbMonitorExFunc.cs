using System;
using CSFramework.ORM.Data;
using CSFramework.ORM.ExFunc.DbMonitorProvider;
using SqlSugar;

namespace CSFramework.ORM.ExFunc
{
    public static class DbMonitorExFunc
    {
        public static void MonitorRegister<T>(this ISugarQueryable<T> query, Action<object, DbNotifyEventArgs> handle)
        {
            var instance = MonitorFactory.CreateInstance(query.Context.CurrentConnectionConfig.DbType);
            instance.MonitorRegister(query, handle);
        }


        public static void MonitorStart(this SqlSugarClient client)
        {
            var instance = MonitorFactory.CreateInstance(client.CurrentConnectionConfig.DbType);
            instance.MonitorStart(client);
        }

        public static void MonitorStop(this SqlSugarClient client)
        {
            var instance = MonitorFactory.CreateInstance(client.CurrentConnectionConfig.DbType);
            instance.MonitorStop(client);
        }


    }
}
