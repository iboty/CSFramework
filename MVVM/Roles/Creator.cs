using System;
using System.Collections.Generic;
using CSFramework.Common;
using CSFramework.Common.Data;
using CSFramework.MVVM.Data;
using CSFramework.MVVM.Factories;
using CSFramework.MVVM.Interface;


// ReSharper disable once IdentifierTypo
namespace CSFramework.MVVM.Roles
{
    public  class Creator
    {
        private static readonly Dictionary<string,IFactory> FactoryDictionary = new Dictionary<string, IFactory>();

        private static readonly Dictionary<Type, object> SingleInstanceDictionary = new Dictionary<Type, object>();

        private static readonly object InstanceLock = new  object();

        private static IFactory _defaultBllFactory;

        private static IFactory _defaultDalFactory;

        /// <summary>
        /// 从文件中加载工厂
        /// </summary>
        public static void LoadConfig()
        {
            FactoryDictionary.Clear();
            var infoList =FrameworkInfoLoader.FrameworkInfo.FactoryInfoList;

            if (infoList == null) throw new Exception("工厂连接信息为空");

            foreach (var info in infoList)
            {
                var factory = NewFactory(info);
                FactoryDictionary.Add(info.Name, factory);
                if (info.LayerType == LayerType.Bll &&  info.IsDefault) _defaultBllFactory = factory;
                if(info.LayerType == LayerType.Dal && info.IsDefault) _defaultDalFactory = factory;
            }
        }

        /// <summary>
        /// 简单的工厂创建
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static IFactory NewFactory(FactoryInfo info)
        {
            if(info.FactoryType == FactoryType.MEF) return new MefFactory(info);
            if(info.FactoryType == FactoryType.WCF) return new WcfFactory(info);
            throw new Exception("工厂类型不支持");
        }

        /// <summary>
        /// 注册工厂
        /// </summary>
        /// <param name="key"></param>
        /// <param name="factory"></param>
        public static void RegisterFactory(string key, IFactory factory)
        {
            if (FactoryDictionary.ContainsKey(key)) FactoryDictionary[key] = factory;
            else FactoryDictionary.Add(key, factory);
        }




        /// <summary>
        /// 注销工厂
        /// </summary>
        /// <param name="key"></param>
        public static void UnRegisterFactory(string key)
        {
            if (FactoryDictionary.ContainsKey(key)) FactoryDictionary.Remove(key);
        }

       
        public static void ReleaseSingleInstant<T>(T instant) 
        {
            var type = typeof(T);
            lock (InstanceLock)
            {
                if (SingleInstanceDictionary.ContainsKey(type)) SingleInstanceDictionary.Remove(type);
            }
        }

        /// <summary>
        /// 业务层实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T InstantBll<T>(string name = null, string key = null)
        {
            return Instant<T>(name, key,SoftLayer.Bll,false);
        }

        /// <summary>
        /// 数据层实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T InstantDal<T>(string name = null, string key = null)
        {
            return Instant<T>(name,key,SoftLayer.Dal,false);
        }


        internal static T Instant<T>(string name ,string key, SoftLayer layer, bool isSingle)
        {
            if(!isSingle) return Instant<T>(name ,key,  layer);

            lock (InstanceLock)
            {
                var type = typeof(T);

                T obj;

                if (SingleInstanceDictionary.ContainsKey(type))
                {
                    obj = (T)SingleInstanceDictionary[type];
                }
                else
                {
                    obj = Instant<T>(name, key, layer);
                    SingleInstanceDictionary.Add(type,obj);
                }

                return obj;
            }

        }

        /// <summary>
        /// 通用接口和抽象类实例化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        internal static T Instant<T>(string name, string key, SoftLayer layer)
        {

            if (FactoryDictionary.Count == 0) LoadConfig();
            if (key == null)
            {
                var factory = layer == SoftLayer.Bll ? _defaultBllFactory : _defaultDalFactory;
                if (factory == null) throw new Exception($"{layer}默认工厂不存在");
                return string.IsNullOrEmpty(name) ? factory.Create<T>() : factory.Create<T>(name);
            }

            if (FactoryDictionary.ContainsKey(key)) throw new Exception($"key:{key}包含的工厂不存在");
            return string.IsNullOrEmpty(name) ?  FactoryDictionary[key].Create<T>() : FactoryDictionary[key].Create<T>(name);
        }

    }
}
