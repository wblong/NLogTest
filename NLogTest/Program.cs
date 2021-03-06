﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

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

            #region 代码动态调用配置
            ///////////////////////////////////////////////////////////////////////////////////////////
            // Step 1. Create configuration object 

            LoggingConfiguration config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration 

            ColoredConsoleTarget consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            FileTarget fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties 

            consoleTarget.Layout = "${date:format=HH\\:MM\\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/file.txt";
            fileTarget.Layout = "${message}";

            // Step 4. Define rules 

            LoggingRule rule1 = new LoggingRule("*", LogLevel.Debug, consoleTarget);
            config.LoggingRules.Add(rule1);

            LoggingRule rule2 = new LoggingRule("*", LogLevel.Debug, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration 

            LogManager.Configuration = config;

            // Example usage 

            Logger logger = LogManager.GetLogger("Example");
            logger.Trace("trace log message");
            logger.Debug("debug log message");
            logger.Info("info log message");
            logger.Warn("warn log message");
            logger.Error("error log message");
            logger.Fatal("fatal log message");
            #endregion
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
