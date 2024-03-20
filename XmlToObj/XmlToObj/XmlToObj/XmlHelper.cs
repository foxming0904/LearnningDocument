using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.InteropServices.ComTypes;

namespace XmlToObj
{
    /// <summary>
    /// xml帮助类
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 将Xml格式字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="xmlContent">xml格式字符串</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlContent) where T : class
        {
            try
            {
                using (var xmlReader = XmlReader.Create(new StringReader(xmlContent)))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    return (T)xs.Deserialize(xmlReader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return default(T);
            }

        }

        /// <summary>
        /// 序列化object对象为XML字符串
        /// </summary>
        /// <param name="model">实体类或List集合类</param>
        /// <param name="isOmitXmlDeclaration"><![CDATA[是否去除Xml声明<?xml version="1.0" encoding="utf-8"?>]]></param>
        /// <param name="isIndent">是否缩进显示</param>
        public static string Serialize<T>(T model) where T : class
        {
            try
            {
                string xmlString;
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();

                //去除xml声明
                //<?xml version="1.0" encoding="utf-8"?>
                xmlWriterSettings.OmitXmlDeclaration = false;
                //不换行不缩进
                xmlWriterSettings.Indent = true;
                //默认为UTF8编码
                xmlWriterSettings.Encoding = new UTF8Encoding(false);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings))
                    {
                        //去除默认命名空间xmlns:xsd和xmlns:xsi
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add(string.Empty, string.Empty);

                        //序列化对象
                        XmlSerializer xmlSerializer = new XmlSerializer(model.GetType());
                        xmlSerializer.Serialize(xmlWriter, model, ns);
                    }
                    xmlString = Encoding.UTF8.GetString(memoryStream.ToArray());
                }
                return xmlString.TrimStart('?');
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "";
            }

        }
    }
}
