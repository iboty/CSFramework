using System;
using System.Data;
using System.Data.SqlClient;
using CSFramework.ORM.Data;
using CSFramework.ORM.Interface;
using SqlSugar;

namespace CSFramework.ORM.DbMintor
{
    internal  class SqlServerMonitor : IDbMonitor
    {
        public void Monitor<T>(ISugarQueryable<T> query, Action<object, DbNotifyEventArgs>  handle)
        {
            var conn = new SqlConnection(query.Context.CurrentConnectionConfig.ConnectionString);

            conn.Open();
            var cmd = new SqlCommand
            {
                Connection = conn,
                CommandText = query.ToSql().Key,
                CommandType = CommandType.Text
            };
            var dep = new SqlDependency(cmd);
            dep.OnChange += (o, e) => { handle(o,new DbNotifyEventArgs(e)); };
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
