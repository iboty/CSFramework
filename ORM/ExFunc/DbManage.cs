using System;
using System.Linq;
using System.Reflection;
using CSFramework.ORM.Data;
using SqlSugar;

namespace CSFramework.ORM.ExFunc
{
    public static   class DbManage
    {
        public static void InitDbInstance(this SqlSugarClient client, string assemblyName , string nameSpace , bool isCheckVer = true)
        {
           var isCreateDb =  client.DbMaintenance.CreateDatabase();

            var assembly = Assembly.Load(assemblyName);
            var entityClasses = assembly.GetTypes();

            if (isCheckVer)
            {
                client.CodeFirst.InitTables<DbVerInfo>();
                var verInfo = client.Queryable<DbVerInfo>().OrderBy(t => t.UpdateTime, OrderByType.Desc).First() ?? new DbVerInfo();

                var curVerInfo = assembly.GetName().Version;
                var oldVerInfo = new Version(verInfo.Version);
                if (curVerInfo <= oldVerInfo) return;

                entityClasses = entityClasses.Where(t => t.Namespace == nameSpace && t.IsClass && !t.Name.StartsWith("<>c")).ToArray();

                foreach (var entityClass in entityClasses)
                {
                    client.CodeFirst.InitTables(entityClass);
                }

                verInfo.Version = curVerInfo.ToString();
                verInfo.UpdateTime = DateTime.Now;
                client.Insertable(verInfo).ExecuteCommand();
            }
            else
            {
                foreach (var entityClass in entityClasses)
                {
                    if (entityClass.Namespace != nameSpace || !entityClass.IsClass) continue;
                    client.CodeFirst.InitTables(entityClass);
                }
            }
        }

        public static void CreateEntityFiles(this SqlSugarClient client,string path , string[] tableArray = null)
        {
            if (tableArray == null) client.DbFirst.CreateClassFile(path);
            else client.DbFirst.Where(tableArray).CreateClassFile(path);
        }

       
    }
}
