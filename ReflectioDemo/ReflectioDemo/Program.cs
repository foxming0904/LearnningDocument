using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectioDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Man man = new Man()
            {
                Name = "FOX",
                Age = 18,
                IsLock = false
            };

            var type = man.GetType();
            var pops = type.GetProperties();

            foreach (var e in pops)
            {
                var val = e.GetValue(man);
                Console.WriteLine($"name:{e.Name},value:{val}");

                var attr = e.GetCustomAttributes<BotAttribute>();
                if (attr.Count()>0)
                {
                    Console.WriteLine($"Name:{e.Name},AttributeVal:{attr.ToList()[0].IsEnable}");
                }
            } 

            Console.Read();
        }
    }

    public class Man
    {
        public string Name { get; set; }
        [Bot(true)]
        public int Age { get; set; }
        public bool IsLock { get; set; }
    }

    public class BotAttribute : Attribute
    {
        public BotAttribute(bool Isenable)
        {

            IsEnable = Isenable;
        }

        public bool IsEnable { get; private set; }
    }
}
