using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Layout;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Config;

namespace Log4netDynamic
{
    internal class LogCreator
    {

        /// <summary>
        /// 创建Logger
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static ILog GetLoggerByName(string name, Level level)
        {
            var logger = GetLoggerByName(name);
            SetMinLogLevel(name, level);
            return logger;

        }

        /// <summary>
        /// 创建Logger
        /// </summary>
        /// <param name="name">Logger名称</param>
        /// <returns></returns>
        private static ILog GetLoggerByName(string name)
        {
            if (LogManager.Exists(name) == null)
            {

                // Pattern Layout defined
                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date %level %logger - %message%newline";
                patternLayout.ActivateOptions();

                // configurating the RollingFileAppender object
                RollingFileAppender appender = new RollingFileAppender();
                appender.Name = name;
                appender.AppendToFile = true;
                appender.File = $"Log\\{name}.log";
                appender.StaticLogFileName = true;
                appender.PreserveLogFileNameExtension = true;
                appender.LockingModel = new FileAppender.MinimalLock();
                appender.Layout = patternLayout;
                appender.MaxSizeRollBackups = 1000;
                appender.MaximumFileSize = "1MB";
                appender.RollingStyle = RollingFileAppender.RollingMode.Composite;
                appender.ActivateOptions();

                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                var loger = hierarchy.GetLogger(name, hierarchy.LoggerFactory); //!!! 此处写法是重点，不容更改，试试就逝世
                loger.Hierarchy = hierarchy;
                loger.AddAppender(appender);
                loger.Level = Level.All;

                BasicConfigurator.Configure();//!!! 此处写法是重点，不容更改，试试就逝世

                var appname = Assembly.GetEntryAssembly().GetName().Name;
                var version = Assembly.GetEntryAssembly().GetName().Version;
                loger.Log(Level.Info, $"Log name {name} created for Application: {appname} Version: {version}", null);
            }
            var log = LogManager.GetLogger(name);
            return log;
        }



        /// <summary>
        /// 设置Logger等级
        /// </summary>
        /// <param name="level">最低等级</param>
        /// <param name="name">Logger实例名称</param>
        private static void SetMinLogLevel(string name, Level level)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            if (hierarchy.Exists(name) is Logger loger)
            {
                loger.Level = level;
            }
        }
    }
}
