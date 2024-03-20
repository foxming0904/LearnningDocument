using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                Console.WriteLine("1.“伪”暴击模拟");
                Console.WriteLine("2.“真”暴击模拟");
                Console.WriteLine("3. Exit...");

                var flag = Console.ReadLine();

                switch (flag)
                {
                    case "1": FakeCriHit(); break;
                    case "2": TrueCriHit(); break;
                    case "3": run = false; break;
                    default: break;
                }
            }
            Console.Read();
        }

        static void FakeCriHit()
        {
            Console.WriteLine("输入临界值（百分比不用输入%）：");
            var tsd = int.Parse(Console.ReadLine());

            Console.WriteLine("输入尝试次数：");
            var count = int.Parse(Console.ReadLine());

            int tsd2 = tsd;
            List<string> tag = new List<string>();
            var rd = new Random();
            for (int i = 1; i <= count; i++)
            {
                var random = rd.Next(1, 100);
                if (random <= tsd2)
                {
                    tag.Add("1");
                    tsd2 = tsd;     //重置几率
                }
                else
                {
                    tag.Add("0");
                    tsd2 = tsd > 85 ? 95 : tsd2 + 10;   //补偿机制，增加概率
                }
            }
            Console.WriteLine($"暴击{tag.Where(c => c.Equals("1")).Count()}次，失败{tag.Where(c => c.Equals("0")).Count()}次");
            Console.WriteLine(String.Join("", tag));
            Console.WriteLine();
        }

        static void TrueCriHit()
        {
            Console.WriteLine("输入临界值（百分比不用输入%）：");
            var tsd = int.Parse(Console.ReadLine());

            Console.WriteLine("输入尝试次数：");
            var count = int.Parse(Console.ReadLine());

            int tsd2 = tsd;
            List<string> tag = new List<string>();
            var rd = new Random();
            for (int i = 1; i <= count; i++)
            {
                var random = rd.Next(1, 100);
                if (random <= tsd2)
                {
                    tag.Add("1"); 
                }
                else
                {
                    tag.Add("0"); 
                }
            }
            Console.WriteLine($"暴击{tag.Where(c => c.Equals("1")).Count()}次，失败{tag.Where(c => c.Equals("0")).Count()}次");
            Console.WriteLine(String.Join("", tag));
            Console.WriteLine();
        }
    }
}
