using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

using System;
using System.IO;

namespace FlexiObject.Core.Logging
{
    public abstract class AlogSetuper
    {
        protected readonly Log4JXmlEventLayout _log4XmlLayout = new ();
        protected readonly string _commonLayout = "${longdate}|${level}|${message} |${all-event-properties} ${exception:format=tostring}";
        public virtual bool HasConsoleLog { get; }
        public virtual bool HasNetworkLog { get; }
        public virtual bool HasDbLogging { get; }
        public virtual string LogPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"Flexiobject", "Logs");
        public virtual LoggingConfiguration Setup()
        {
            var commonTargetName = GetType().Assembly.GetName().Name;
            var config = new LoggingConfiguration();

            var target =
                    new FileTarget
                    {
                        FileName = Path.Combine(LogPath, commonTargetName + ".log4j"),
                        Name = commonTargetName,
                        AutoFlush = true,
                        Layout = _log4XmlLayout
                    };

            config.AddTarget("logfile", target);


            if (HasConsoleLog)
            {
                var consoleTarget = new ConsoleTarget
                {
                    AutoFlush = true,
                    Encoding = System.Text.Encoding.UTF8,
                    Name = "console",
                    Layout = _commonLayout
                };

                config.AddTarget(consoleTarget);
            }

            if (HasNetworkLog)
            {
                var networkTarget = new NetworkTarget
                {
                    Address = "tcp4://127.0.0.1:5095",
                    Layout = _log4XmlLayout,
                    Name = "network"
                };

                config.AddTarget(networkTarget);
            }

            config.AddRuleForAllLevels("logfile");
            config.AddRuleForAllLevels("console");
            config.AddRuleForAllLevels("network");

            SetupCustomLogging(config);

            LogManager.Configuration = config;
            return config;
        }

        /// <summary>
        /// Declare custom logging targets and rules
        /// </summary>
        /// <param name="config"></param>
        public virtual void SetupCustomLogging(LoggingConfiguration config)
        {

        }
    }
}
