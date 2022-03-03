using System;
using System.Data.SqlClient;
using CSFramework.ORM.Data;
using CSFramework.ORM.Interface;
using SqlSugar;

namespace CSFramework.ORM.ExFunc.DbMonitorProvider
{
    internal  class SqlServerProvider : IDbMonitor
    {
       

        public void MonitorRegister<T>(ISugarQueryable<T> query, Action<object, DbNotifyEventArgs>  handle)
        {
            using (var conn = new SqlConnection(query.Context.CurrentConnectionConfig.ConnectionString))
            {
                conn.Open();

                var cmd = new SqlCommand(query.ToSql().Key, conn);

                var dep = new SqlDependency(cmd);

                dep.OnChange += (o, e) => { handle(o, new DbNotifyEventArgs(e)); };

                cmd.ExecuteNonQuery();

                conn.Close();
            }

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
