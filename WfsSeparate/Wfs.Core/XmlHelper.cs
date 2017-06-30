using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wfs.Core
{
    public static class XmlHelper
    {
        /// <summary>
        /// 反序列化xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static T DesearializerXml<T>(string xml) where T : class,new()
        {
            TextReader reader = new StringReader(xml);
            XmlSerializer xmlSearializer = new XmlSerializer(typeof(T));
            T info = (T)xmlSearializer.Deserialize(reader);
            reader.Close();
            reader.Dispose();
            return info;
        }

        /// <summary>
        /// 序列化xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SearializerXml<T>(T obj) where T : class,new()
        {
            StringWriter sw = new StringWriter();
            //创建XML命名空间
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(sw, obj, ns);
            sw.Close();
            sw.Dispose();
            return sw.ToString();
        }
    }
}
