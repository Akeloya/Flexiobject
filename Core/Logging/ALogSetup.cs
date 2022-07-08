using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

using System.IO;

namespace CoaApp.Core.Logging
{
    public abstract class AlogSetuper
    {
        public virtual bool HasConsoleLog { get; }
        public virtual bool HasNetworkLog { get; }
        public virtual bool HasDbLogging { get; }
        public virtual string LogPath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        public virtual LoggingConfiguration Setup()
        {
            var commonTargetName = GetType().Assembly.GetName().Name;
            var commonLayout = "${longdate}|${level}|${message} |${all-event-properties} ${exception:format=tostring}";

            var log4jLayout = new Log4JXmlEventLayout();
            var config = new LoggingConfiguration();

            var target =
                    new FileTarget
                    {
                        FileName = Path.Combine(LogPath, commonTargetName + ".log4j"),
                        Name = commonTargetName,
                        AutoFlush = true,
                        Layout = log4jLayout
                    };

            config.AddTarget("logfile", target);


            if (HasConsoleLog)
            {
                var consoleTarget = new ConsoleTarget
                {
                    AutoFlush = true,
                    Encoding = System.Text.Encoding.UTF8,
                    Name = "console",
                    Layout = commonLayout
                };

                config.AddTarget(consoleTarget);
            }

            if (HasNetworkLog)
            {
                var networkTarget = new NetworkTarget
                {
                    Address = "tcp://127.0.0.1:5095",
                    Layout = log4jLayout,
                    Name = "network"
                };

                config.AddTarget(networkTarget);
            }

            config.AddRuleForAllLevels("logfile");
            config.AddRuleForAllLevels("console");
            config.AddRuleForAllLevels("network");

            LogManager.Configuration = config;
            return config;
        }
    }
}
