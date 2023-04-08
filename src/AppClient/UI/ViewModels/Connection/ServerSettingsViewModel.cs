using FlexiObject.API.Settings;

using System.Threading.Tasks;

namespace FlexiObject.AppClient.UI.ViewModels.Connection
{
    public class ServerSettingsViewModel : ASettingsViewModel
    {
        public ServerSettingsViewModel(IFlexiConnection connection)
        {
            Settings = connection as AppServerSettings ?? new AppServerSettings();
            Discard();
        }
        public AppServerSettings Settings { get; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }

        public override void Apply()
        {
            Settings.Name = Name;
            Settings.Host = Host;
            Settings.Port = Port;
        }

        public override async Task ApplyAsync()
        {
            Apply();
            await Settings.SaveAsync();
        }

        public override void Discard()
        {
            Host = Settings.Host;
            Port = Settings.Port;
            Name = Settings.Name;
        }
    }
}
