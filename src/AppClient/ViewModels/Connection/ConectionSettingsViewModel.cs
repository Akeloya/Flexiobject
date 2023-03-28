using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Settings;

using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    public class ConnectionSettingsViewModel : ViewModelBase
    {
        public ConnectionSettingsViewModel()
        {
        }

        public static ConnectionSettingsViewModel Design => new();        
        public ObservableCollection<IFlexiConnection> Connections { get; set; } = new(){
            new AppServerSettings { Host = "localhost", Port = 55, Name="appserver", UseWindows = false },
            new StandaloneSettings { Name ="localdb", ServerName="localhost", DbType = DbProvider.DbTypes.MsSqlServer, DatabaseName="appdb", UserName = "flexiobject_data", UserPassword="123456" }
            };
        public IFlexiConnection SelectedSettings { get; set; }
        private void OnSelectedSettingsChanged()
        {
            if(SelectedSettings is AppServerSettings) 
            {
                SelectedSettingsViewModel = new ServerSettingsViewModel();
                return;
            }

            SelectedSettingsViewModel = new StandaloneSettingsViewModel();
        }
        public object SelectedSettingsViewModel { get; set; }
        public Task Close()
        {
            return TryCloseAsync();
        }

        public Task Apply()
        {
            return Task.CompletedTask;
        }
    }
}
