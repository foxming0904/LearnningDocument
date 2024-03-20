using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  int[] arr = new int[] { 7, 6, 5, 8, 4, 9, 1, 2, 3 };
            string[] sarr = new string[] { "c", "d", "b", "a", };
           
            var linqArr = from s in sarr
                     orderby s ascending select s; 
            var orderArr =sarr.OrderByDescending(s => s); 
            var stArr=sarr.Where(c=>!string.IsNullOrWhiteSpace(c)).Skip(2).Take(2);

            Console.WriteLine(string.Join(",", stArr));
            Console.Read();
        }
    }
}
