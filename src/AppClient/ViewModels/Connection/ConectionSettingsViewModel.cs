using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Exceptions;
using FlexiObject.AppClient.Core.Settings;

using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    public class ConnectionSettingsViewModel : ViewModelBase
    {
        private readonly FlexiConnectionFactory _connectionFactory;
        public ConnectionSettingsViewModel(FlexiConnectionFactory flexiConnectionFactory)
        {
            _connectionFactory = flexiConnectionFactory;
        }

        public static ConnectionSettingsViewModel Design => new(null);
        public ObservableCollection<IFlexiConnection> Connections { get; set; } = new(){
            new AppServerSettings { Host = "localhost", Port = 55, Name="appserver", UseWindows = false },
            new StandaloneSettings { Name ="localdb", ServerName="localhost", DbType = DbProvider.DbTypes.MsSqlServer, DatabaseName="appdb", UserName = "flexiobject_data", UserPassword="123456" }
            };
        
        public bool IsStandalone {get;set; }
        public IFlexiConnection SelectedSettings { get; set; }
        private void OnSelectedSettingsChanged()
        {
            if (SelectedSettings is AppServerSettings)
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

        public async Task Apply()
        {
            try
            {
                await SelectedSettings.SaveAsync();
            }
            catch (InvalidOperationException)
            {
                await DialogService.ShowErrorAsync("Необходимо заполнить поля");
            }
            catch(System.Exception ex)
            {
                await DialogService.ShowErrorAsync($"Failed to apply {ex}");
            }
            
        }

        public void Add()
        {
            var settings = _connectionFactory.Create(IsStandalone);
            Connections.Add(settings);
            SelectedSettings = settings;
        }

        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
            Connections = new ObservableCollection<IFlexiConnection>(await _connectionFactory.GetConnections());
        }
    }
}
