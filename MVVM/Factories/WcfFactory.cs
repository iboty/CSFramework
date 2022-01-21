using System.ServiceModel;
using CSFramework.Common.Data;
using CSFramework.MVVM.Interface;

// ReSharper disable All
namespace CSFramework.MVVM.Factories
{
    public  class WcfFactory : IFactory
    {
       

        /// <summary>
        ///  根目录地址
        /// </summary>
        private string _baseAddr;
        private BasicHttpBinding _binding;
        /// <summary>
        /// 根据接口或父类对象创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>()
        {
            var endPoint = new EndpointAddress($"{_baseAddr}/{typeof(T).Name}");
            var factory = new ChannelFactory<T>(_binding, endPoint);
            var server = factory.CreateChannel();
            return server;
        }

        public T Create<T>(string name)
        {
            throw new ActionNotSupportedException("带参数加载方式不支持");
        }

        public WcfFactory(FactoryInfo info)
        {
            _baseAddr = info.BasePath.TrimEnd('/');
            _binding = new BasicHttpBinding
            {
                MaxBufferPoolSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
        }
    
    }
}
