using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using CSFramework.Common.Data;
using CSFramework.MVVM.Interface;

// ReSharper disable once IdentifierTypo
namespace CSFramework.MVVM.Factories
{
    public  class MefFactory : IFactory
    {
        /// <summary>
        /// 程序集容器
        /// </summary>
        private readonly CompositionContainer _container;

        /// <summary>
        /// 根据接口或父类对象创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>()
        {
           var instance =  _container.GetExportedValue<T>();
           return instance;
        }

        public T Create<T>(string name)
        {
            var instance = _container.GetExportedValue<T>(name);
            return instance;
        }

        public  MefFactory(FactoryInfo info)
        {
           var path = info.BasePath ?? AppDomain.CurrentDomain.BaseDirectory ;
            if (!Directory.Exists(path)) throw new Exception($"加载程序集路径{path}不存在");

            var assemblyCatalog = new DirectoryCatalog(path, info.LibFileRule);
            _container = new CompositionContainer(assemblyCatalog);
        }

    }
    


}
