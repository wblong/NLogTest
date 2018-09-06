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
            LogManager.Flush();
        }
        public static void WriteLog()
        {
            Logger.Log(LogLevel.Error, "nlog test error");
        }
    }
}
