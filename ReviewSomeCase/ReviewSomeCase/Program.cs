using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewSomeCase
{
    class Program
    {
        static void Main(string[] args)
        {
            UserRequest req = new UserRequest()
            {
                Visits = 5,
                Reason = "study",
                UserName = "fox"

            }; 
            Console.WriteLine($"name:{req.UserName},url:{req.UrlStr},visits:{req.Visits},reason:{req.Reason}");
            Console.Read();
        }
    }
}
