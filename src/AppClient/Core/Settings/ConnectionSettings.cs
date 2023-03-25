using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

using System.Collections.Generic;

namespace FlexiObject.AppClient.Core.Settings
{
    public interface IConnection
    {
        public string Name { get; set; }
    }
    public class AppServerSettings : IConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseWindows { get; set; }
        public string Name { get; set; }
    }

    public static class ConnectionEx
    {
        public static AppServerSettings GetServerSettings(this IConnection connection)
        {
            if (connection is not AppServerSettings)
                return null;
            return connection as AppServerSettings;
        }
        public static StandaloneSettings GetStandalone(this IConnection connection)
        {
            if (connection is not StandaloneSettings)
                return null;
            return connection as StandaloneSettings;
        }
    }


    public class StandaloneSettings : AppDbSettings, IConnection
    {
        public string Name { get; set; }
    }
    [JsonSettingSubFolder("Settings")]
    public class ConnectionSettings : AJsonSettings
    {
        public string SelectedSettings { get; set; }
        public bool StandaloneMode { get; set; }
        public List<AppServerSettings> ServerSettings { get; set; } = new();
        public List<StandaloneSettings> StandaloneSettings { get; set; } = new();
    }
}
