using FlexiObject.API.Settings;
using FlexiObject.AppClient.Core;
using FlexiObject.Core.Exceptions;

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
            new AppServerSettings { Host = "localhost", Port = 55, Name="appserver"},
            new StandaloneSettings { Name ="localdb", ServerName="localhost", DbType = DbProvider.DbTypes.MsSqlServer, DatabaseName="appdb", UserName = "flexiobject_data", UserPassword="123456" }
            };

        public bool IsStandalone { get; set; } = true;
        public IFlexiConnection SelectedSettings { get; set; }
        private void OnSelectedSettingsChanged()
        {
            if (SelectedSettings == null)
            {
                SelectedSettingsViewModel = null;
                return;
            }

            if (SelectedSettings is AppServerSettings)
            {
                SelectedSettingsViewModel = new ServerSettingsViewModel(SelectedSettings);
                return;
            }

            SelectedSettingsViewModel = new StandaloneSettingsViewModel(SelectedSettings);
        }
        public ASettingsViewModel SelectedSettingsViewModel { get; set; }
        public Task Close()
        {
            return TryCloseAsync();
        }

        public async Task Apply()
        {
            try
            {
                await SelectedSettingsViewModel.ApplyAsync();
            }
            catch (InvalidOperationException)
            {
                await DialogService.ShowErrorAsync("Необходимо заполнить поля");
            }
            catch (System.Exception ex)
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

        public async void Remove()
        {
            if (SelectedSettings == null)
                return;

            try
            {
                await SelectedSettings.RemoveThis();
                SelectedSettings = null;
            }
            catch (System.Exception ex)
            {
                await DialogService.ShowErrorAsync(ex);
            }
            finally
            {
                Connections = new ObservableCollection<IFlexiConnection>(await _connectionFactory.GetConnections());
            }

        }

        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
            Connections = new ObservableCollection<IFlexiConnection>(await _connectionFactory.GetConnections());
        }
    }
}
