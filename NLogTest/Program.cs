using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;


namespace NLogTest
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            WriteLog();
            LOG.Logger.Default.Debug("Default debug message{0}{1}{2}",1,2,3);
            Logger.Trace("Sample trace message");
            Logger.Debug("Sample debug message");
            Logger.Info("Sample informational message");
            Logger.Warn("Sample warning message");
            Logger.Error("Sample error message");
            Logger.Fatal("Sample fatal error message");

            int k = 42;
            int l = 100;

            Logger.Trace("Sample trace message, k={0}, l={1}", k, l);
            Logger.Debug("Sample debug message, k={0}, l={1}", k, l);
            Logger.Info("Sample informational message, k={0}, l={1}", k, l);
            Logger.Warn("Sample warning message, k={0}, l={1}", k, l);
            Logger.Error("Sample error message, k={0}, l={1}", k, l);
            Logger.Fatal("Sample fatal error message, k={0}, l={1}", k, l);
            Logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", k, l);

            LogManager.Flush();
        }
        public static void WriteLog()
        {
            Logger.Log(LogLevel.Error, "nlog test error");
            Logger.Log(LogLevel.Debug, "nlog debug");
            Logger.Log(LogLevel.Info, "nlog Info");
            Logger.Log(LogLevel.Fatal, "nlog fatal");
        }
    }
}
