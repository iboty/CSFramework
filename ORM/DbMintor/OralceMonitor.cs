using System;
using System.Data;
using System.Data.SqlClient;
using CSFramework.ORM.Data;
using CSFramework.ORM.Interface;
using Oracle.ManagedDataAccess.Client;
using SqlSugar;

namespace CSFramework.ORM.DbMintor
{
    internal  class OralceMonitor : IDbMonitor
    {
        public void Monitor<T>(ISugarQueryable<T> query, Action<object, DbNotifyEventArgs>  handle)
        {
            var conn = new OracleConnection(query.Context.CurrentConnectionConfig.ConnectionString);

            conn.Open();
            var cmd = new OracleCommand()
            {
                Connection = conn,
                CommandText = query.ToSql().Key,
                CommandType = CommandType.Text
            };
            var dep = new OracleDependency(cmd);
            dep.OnChange += (o,e)=>{ handle(o, new DbNotifyEventArgs(e));};
            cmd.ExecuteReader();
        }

        public void MonitorStart(SqlSugarClient client)
        {
            SqlDependency.Start(client.CurrentConnectionConfig.ConnectionString);
        }

        public void MonitorStop(SqlSugarClient client)
        {
            SqlDependency.Stop(client.CurrentConnectionConfig.ConnectionString);
        }
    }
}
