using System.IO;
using System.Xml.Serialization;

namespace CSFramework.Common.Helper
{
    public static class XmlHelper
    {
        /// <summary>
        ///  从指定文件路径中转换xml对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T ToObjectFromFile<T>(string filePath)
        {
            using (var stream = new StreamReader(filePath))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }
        /// <summary>
        ///  保存xml文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static void SaveFileFromObject<T>(T obj, string filePath)
        {
            using (var stream = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(T));
                var xns = new XmlSerializerNamespaces();
                xns.Add("", "");
                serializer.Serialize(stream, obj, xns);
            }
        }

    }
}
