using System;
using CSFramework.ORM.Data;
using SqlSugar;

namespace CSFramework.ORM.Interface
{
    public interface IDbMonitor
    {
        void MonitorRegister<T>(ISugarQueryable<T> query,Action<object,DbNotifyEventArgs> handle);
        void MonitorStart(SqlSugarClient client);
        void MonitorStop(SqlSugarClient client);
    }
}
