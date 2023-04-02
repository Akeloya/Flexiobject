using Avalonia.Controls;

using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Settings;
using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.Core.Logging;

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IJsonSettingsStore _settingsStore;
        private readonly FlexiConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private bool _disableChanging;
        public LoginViewModel(IJsonSettingsStore jsonSettingsStore, FlexiConnectionFactory connectionFactory, LoggerFactory loggerFactory)
        {
            if(Design.IsDesignMode)
                return;
            _logger = loggerFactory.Create<LoginViewModel>();
            _settingsStore = jsonSettingsStore;
            _connectionFactory = connectionFactory;
            Version = GetType().Assembly.GetName().Version.ToString();
        }
        public static LoginViewModel Create => new(null, null, null);
        public string Version { get; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ConnectionInfo { get; set; }
        public ObservableCollection<IFlexiConnection> Connections { get; set; } = new();
        public IFlexiConnection SelectedConnection { get; set; }
        private async void OnSelectedConnectionChanged()
        {
            if (_disableChanging)
                return;
            try
            {
                var settings = await _settingsStore.LoadAsync<ConnectionSettings>();
                settings.SelectedSettings = SelectedConnection?.Name;
                await _settingsStore.SaveAsync(settings);
                ConnectionInfo = SelectedConnection?.BuildInfo();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                await DialogService.ShowErrorAsync(ex);
            }
        }
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            try
            {
                var connectionSettings = await _settingsStore.LoadAsync<ConnectionSettings>();

                foreach (var sett in connectionSettings.StandaloneSettings)
                    Connections.Add(sett);

                foreach (var sett in connectionSettings.ServerSettings)
                    Connections.Add(sett);

                if (string.IsNullOrWhiteSpace(connectionSettings.SelectedSettings))
                    return;
                _disableChanging = true;
                SelectedConnection = Connections.First(p => p.Name == connectionSettings.SelectedSettings);
                ConnectionInfo = SelectedConnection?.BuildInfo();
                _disableChanging = false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                await DialogService.ShowErrorAsync(ex);
            }
        }

        public override async Task<bool> CanCloseAsync(CancellationToken cancellationToken = default)
        {
            await DialogService.ShowWarningAsync("Точно выйти?");
            return true;
        }

        public async Task DoLogin()
        {
            if (SelectedConnection == null)
            {
                await DialogService.ShowErrorAsync("Не выбраны настройки подключения");
                return;
            }
            await Task.Run(async () =>
            {
                try
                {
                    var app = ApiFactory.GetOrCreateApi().Create();

                    var session = app.OpenSession("localhost", 9696, null, null);
                    await TryCloseAsync(true);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                    await DialogService.ShowErrorAsync(ex);
                }

            });
        }

        public Task Close()
        {
            return TryCloseAsync();
        }

        public async Task OpenConnectionSettings()
        {
            await DialogService.ShowDialogAsync(new ConnectionSettingsViewModel(_connectionFactory));
            Connections = new ObservableCollection<IFlexiConnection>(await _connectionFactory.GetConnections());
        }

    }
}
