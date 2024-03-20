using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4netDynamic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //  传入Pattern 或者 Appender 理论都可以 
            //  路径在Log/Name.log 
            //  这里只传入Name和Level
            //   级别最：4.FATAL            3.RROR            2.WARN            1.INFO            级别最低：0.DEBUG  
            for (int i = 0; i < i+1; i++)
            {

                var _Logger = LogCreator.GetLoggerByName("EAPLM", log4net.Core.Level.Debug);
                _Logger.Debug("123");
                _Logger.Info("123");
                _Logger.Warn("123");
                _Logger.Error("123");
                _Logger.Fatal("123"); 
            }

            Console.WriteLine("Log created!");
            Console.Read();
        }
    }
}
