using FlexiObject.Core.Config.SettingsStore;

namespace FlexiObject.AppServer.Settings
{
    [JsonSettingSubFolder("Settings")]
    public class ServerSettings : AJsonSettings
    {
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 5555;
    }
}
