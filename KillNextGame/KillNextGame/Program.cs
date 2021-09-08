using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillNextGame
{
    class Program
    {
        /// <summary>
        /// 许多人围成一圈  1，2，3，4... n-1，n  
        /// 第一个杀掉第二个人，第三个人杀掉第四个人，直到一圈结束，再次从1开始重新编号重新开始 
        /// 比如有四个人  1>2 || 3>4  || 1>3      live[1]
        /// 比如有五个人  1>2 || 3>4  || 5>1 ||  3>5    live[3]
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine(KillNext(34));  
            Console.Read();
        }

        public static int KillNext(int num)
        {
            int live = 0;
            //  0直接返回0
            // 1||2 直接返回1
            if (num != 0)
            {
                if (num == 1 || num == 2)
                {
                    live = 1;
                    return live;
                }
            }

            //二进制2的n次幂最高位肯定为1 其余为0
            // 1=1    2=10   4=100
            //为2的n次幂 直接返回1
            if ((num & num - 1) == 0)
            {
                live = 1;
                return live;
            }

            //循环求出小于num最接近num的2的n次方
            int po = 0;  //次方 
            int number = num;
            while (true)
            { 
                if (number == 1 || number == 0)
                { break; }
                number = number / 2;
                po++; 
            }
            var  tag = num - Math.Pow(2,po);   //求出num-最接近且小于num的2的n次方
            live = Convert.ToInt32(tag * 2 + 1);  
            return live;
        }
    }
}
