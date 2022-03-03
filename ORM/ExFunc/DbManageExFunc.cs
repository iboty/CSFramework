using System;
using System.Linq;
using System.Reflection;
using CSFramework.ORM.Data;
using SqlSugar;

namespace CSFramework.ORM.ExFunc
{


    public static   class DbManageExFunc
    {

        /// <summary>
        /// 初始化数据库实列
        /// </summary>
        /// <param name="client"></param>
        /// <param name="entityAssemblyName">数据库实体对象程序集名称</param>
        /// <param name="entityNameSpace">实体对象命名控件</param>
        public static void InitDbInstance(this SqlSugarClient client, string entityAssemblyName, string entityNameSpace)
        {
            //创建数据实列
            client.DbMaintenance.CreateDatabase();

            //加载数据实体对象的程序集
            var assembly = Assembly.Load(entityAssemblyName);
            var entityTypes = assembly.GetTypes();

            if (!client.DbMaintenance.IsAnyTable("db_update_rec",false))
            {
                client.CodeFirst.InitTables<DbUpdateRecordEntity>();
            }

            //获取版本记录
            var verInfo = client.Queryable<DbUpdateRecordEntity>().OrderBy(t => t.UpdateTime, OrderByType.Desc).First() ?? new DbUpdateRecordEntity();

            //比较当前更新的版本
            var tempVersion = assembly.GetName().Version;
            var curVersion = new Version(tempVersion.Major, tempVersion.Major, tempVersion.Build);
            var oldVersion = new Version(verInfo.Version);

            if (curVersion <= oldVersion) return;

            entityTypes = entityTypes.Where(t => t.Namespace == entityNameSpace && t.IsClass && !t.Name.StartsWith("<>c")).ToArray();

            //把实体对象转换为表对象
            if(entityTypes.Length > 0) client.CodeFirst.InitTables(entityTypes);

            //更新记录
            verInfo.Version = curVersion.ToString();
            verInfo.UpdateTime = DateTime.Now;

            client.Insertable(verInfo).ExecuteCommand();

        }

        public static void CreateEntityFiles(this SqlSugarClient client,string path , string[] tableArray = null)
        {
            if (tableArray == null) client.DbFirst.IsCreateAttribute().CreateClassFile(path);
            else client.DbFirst.Where(tableArray).IsCreateAttribute().CreateClassFile(path);
        }

        public static void TestConnect(this SqlSugarClient client)
        {
            client.Open();
            client.Close();
        }
    }
}
