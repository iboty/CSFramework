using CSFramework.Common.Data;
using SqlSugar;
using System;
using DbType = SqlSugar.DbType;

namespace CSFramework.ORM
{
    public class DbConvert
    {

        public static ConnectionConfig DbInfoToConnectionConfig(DbConnInfo info)
        {
            var dbConfig = new ConnectionConfig()
            {
                ConnectionString = ToConnString(info),
                DbType = info.DbType,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute,
            };
            return dbConfig;
        }

        public static string ToConnString(DbConnInfo info)
        {
            switch (info.DbType)
            {
                case DbType.SqlServer:
                    var port = string.IsNullOrEmpty(info.Port) ? string.Empty : "," + info.Port + ";";
                    var connString = $"server={info.ServerIp} {port};database={info.DbName};uid={info.User};pwd={info.Password}";
                    return connString;

                case DbType.Oracle:
                    port = string.IsNullOrEmpty(info.Port) ? "1521" : info.Port;
                    connString =
                        $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL = TCP)(HOST={info.ServerIp})(PORT={port})))(CONNECT_DATA=(SERVICE_NAME={info.DbName})));User id={info.User};Password={info.Password};";
                    return connString;

                case DbType.MySql:
                    port = string.IsNullOrEmpty(info.Port) ? string.Empty : ";Port=" + info.Port;
                    connString = $"Server={info.ServerIp}{port};Database = {info.DbName}; User = {info.User}; Password = {info.Password};Allow User Variables=true";
                    return connString;

                case DbType.Sqlite:
                    connString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}{info.DbFilePath};";
                    return connString;
                default:
                    throw new Exception("数据库类型不支持");
            }
        }
    }
}
