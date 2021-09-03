using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = BaseConversion(42, 2);
            Console.WriteLine(res);
            Console.Read();
        }

        /// <summary>
        /// 10进制转换
        /// </summary>
        /// <param name="num">数字</param>
        /// <param name="toBase">转换的进制  2,3,4,5,6,7,8,9</param>
        /// <returns></returns>
        private static string BaseConversion(int num, int toBase)
        {
            List<int> list = new List<int>();
            int y = 0;
            while (num >= 1)
            {
                y = num % toBase;
                list.Add(y);
                num = num / toBase; 
            }
                list.Reverse();
            var str = string.Join("",list);
            return str;
        }

    }
}
