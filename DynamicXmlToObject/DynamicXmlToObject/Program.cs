using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicXmlToObject
{ 
    internal class Program
    {
        static void Main(string[] args)
        {

            Demo();
            Console.Read();
        }

        /// <summary>
        /// 例子
        /// </summary>
        public static void Demo()
        {
            //初始化动态类的属性，并且必须要赋初值，全部用字符串表示，
            List<string[]> Propertys = new List<string[]>
                {
                    new string[]{ "byte","studentNo","0"},//byte类型，初始值0或类似(byte)100
                    new string[]{ "char","level","'A'"},//字符型，用单引号加字符
                    new string[]{"short","workdate", "(short)100" },//short类型，用0或类似(short)100
                    new string[] { "int", "id" ,"0"},
                    new string[] { "string","userName","null"},
                    new string[]{"bool","sex","true" },
                    new string[]{"DateTime","jobTime","DateTime.Now" },
                    new string[]{ "List<float>","scores","new List<float>()"},
                    new string[]{ "double","phonePower","0.0"}
                };

            //创建动态类，构建一个程序集
            string className = "Person";
            Assembly assembly = DynamicClassHelper.Newassembly(className, Propertys);

            //构建动态类的实例
            dynamic objclass = assembly.CreateInstance(className);
            //给动态类属性赋值，byte/short/unshort/long/float要强制转换
            DynamicClassHelper.ReflectionSetValue(objclass, "studentNo", (byte)10);
            DynamicClassHelper.ReflectionSetValue(objclass, "level", 'A');
            DynamicClassHelper.ReflectionSetValue(objclass, "workdate", (short)300);
            DynamicClassHelper.ReflectionSetValue(objclass, "id", 1);
            DynamicClassHelper.ReflectionSetValue(objclass, "userName", "XiaoMing Li");
            DynamicClassHelper.ReflectionSetValue(objclass, "sex", true);
            DynamicClassHelper.ReflectionSetValue(objclass, "jobTime", new DateTime(2015, 8, 1));
            DynamicClassHelper.ReflectionSetValue(objclass, "scores", new List<float> { (float)98.2, (float)95.0, (float)88.8 });
            DynamicClassHelper.ReflectionSetValue(objclass, "phonePower", 0.89);

            //创建动态类，构建一个程序集 
            Assembly assembly2 = DynamicClassHelper.Newassembly(className, Propertys);

            //构建动态类的实例
            dynamic objclass2 = assembly.CreateInstance(className);
            //给动态类属性赋值，byte/short/unshort/long/float要强制转换
            DynamicClassHelper.ReflectionSetValue(className, "studentNo", (byte)10);
            DynamicClassHelper.ReflectionSetValue(className, "level", 'A');
            DynamicClassHelper.ReflectionSetValue(className, "workdate", (short)300);
            DynamicClassHelper.ReflectionSetValue(className, "id", 1);
            DynamicClassHelper.ReflectionSetValue(className, "userName", "XiaoMing Li");
            DynamicClassHelper.ReflectionSetValue(className, "sex", true);
            DynamicClassHelper.ReflectionSetValue(className, "jobTime", new DateTime(2015, 8, 1));
            DynamicClassHelper.ReflectionSetValue(className, "scores", new List<float> { (float)98.2, (float)95.0, (float)88.8 });
            DynamicClassHelper.ReflectionSetValue(className, "phonePower", 0.89);

            List<dynamic> list = new List<dynamic>();
            list.Add(objclass);
            list.Add(objclass2);

            //获取动态类相应的属性值，因为返回的是object类，要强制转换后使用(List测试时，可以省略强制转换)
            double phonePower = (double)DynamicClassHelper.ReflectionGetValue(objclass, "phonePower");
            List<float> scores = (List<float>)DynamicClassHelper.ReflectionGetValue(objclass, "scores");


            var xmlContent=XmlHelper.SerializeToXmlStr(list.ToArray(), false);
            Console.WriteLine(xmlContent); 
        }

    }
}
