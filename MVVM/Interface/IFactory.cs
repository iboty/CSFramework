namespace CSFramework.MVVM.Interface
{
    public interface IFactory
    {
        /// <summary>
        /// 根据接口或父类对象创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Create<T>();

        T Create<T>(string name);

    }
}
