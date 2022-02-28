using System;
using System.Collections.Generic;
using CSFramework.Common;
using CSFramework.Common.Data;
using CSFramework.Common.Helper;
using SqlSugar;

namespace CSFramework.ORM
{
    /// <summary>
    /// ORM服务工厂
    /// </summary>
    public static class  DbFactory
    {
        private static readonly Dictionary<string, ConnectionConfig> ConnDictionary = new Dictionary<string, ConnectionConfig>();
        private static ConnectionConfig _defaultConnectionConfig;
        /// <summary>
        /// 从配置中加载连接实例
        /// </summary>
        public static void LoadConnectionConfig()
        {
            ConnDictionary.Clear();

            foreach (var dbInfo in Read.FrameworkInfo.DbInfoList)
            {
                var connInfo = DbConvert.DbInfoToConnectionConfig(dbInfo);
                ConnDictionary.Add(dbInfo.ConnName, connInfo);

                if (dbInfo.IsDefault && _defaultConnectionConfig == null) _defaultConnectionConfig = connInfo;
            }
        }

        /// <summary>
        /// 从配置文件中创建Db
        /// </summary>
        /// <param name="key">配置文件实例名</param>
        /// <returns></returns>
        public static SqlSugarClient CreateDb(string key = null)
        {
            if (ConnDictionary.Count == 0) LoadConnectionConfig();

            if (key == null)
            {
                if (_defaultConnectionConfig == null) throw new Exception("默认连接对象为空");
                return new SqlSugarClient(_defaultConnectionConfig);
            }
            if (!ConnDictionary.ContainsKey(key)) throw new Exception($"连接信息中没有发现实例【{key}】");
            return new SqlSugarClient(ConnDictionary[key]);
        }

        /// <summary>
        /// 创建db数据操作对象实体
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient CreateDb(DbConnInfo info)
        {
            var conn = DbConvert.DbInfoToConnectionConfig(info);
            var client = new SqlSugarClient(conn);
            return client;
        }
       

    }
}
