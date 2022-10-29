using FlexiObject.Core.Logging;

using NLog.Config;
using NLog.Targets;

using System.IO;

namespace FlexiObject.AppServer.Settings
{
    internal class ServerLogSetup : AlogSetuper
    {
        public override bool HasConsoleLog => true;
        public override bool HasNetworkLog => true;
        public const string UserLogName = "UserLogName";
        public override void SetupCustomLogging(LoggingConfiguration config)
        {
            base.SetupCustomLogging(config);

            var target =
                    new FileTarget
                    {
                        FileName = Path.Combine(LogPath, "UserLogs.log4j"),
                        Name = UserLogName,
                        AutoFlush = true,
                        Layout = _log4XmlLayout
                    };
            config.AddTarget(target);
        }
    }
}
