using System;
using System.Collections.Generic;
using System.Reflection;
using CSFramework.Common.Data;
using SqlSugar;

namespace CSFramework.ORM
{
    public static class DbTool
    {
        public static void LocalEntitySync(string entityNamespace, DbInfo info= null)
        {
            var dbClient = DbFactory.CreateDb();
            var dbArray = dbClient.DbMaintenance.GetDataBaseList(null);
            if (dbArray.Contains(info.DbName)) return;
            dbClient.DbMaintenance.CreateDatabase();
            dbClient.CodeFirst.InitTables(entityNamespace);
        }


        public static List<DbTableInfo> GetTableList(DbInfo info)
        {
            var client = DbFactory.CreateDb(info);
            var tables = client.DbMaintenance.GetTableInfoList();
            return tables;
        }

        public static void CheckConnect(DbInfo info)
        {
            var client = DbFactory.CreateDb(info);
             client.Open();
        }

        public static void CreatorCode(DbInfo info, string path ,string[] tableArray = null )
        {
            var client = DbFactory.CreateDb(info);
            if(tableArray == null) client.DbFirst.CreateClassFile(path);
            else
            {
                client.DbFirst.Where(tableArray).CreateClassFile(path);
            }
        }
    }
}
