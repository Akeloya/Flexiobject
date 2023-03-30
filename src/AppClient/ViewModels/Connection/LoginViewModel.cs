using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Settings;
using FlexiObject.AppClient.ViewModels.Connection;
using FlexiObject.Core.Config.SettingsStore;

using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IJsonSettingsStore _settingsStore;
        private readonly FlexiConnectionFactory _connectionFactory;
        public LoginViewModel(IJsonSettingsStore jsonSettingsStore, FlexiConnectionFactory connectionFactory)
        {
            _settingsStore = jsonSettingsStore;
            _connectionFactory = connectionFactory;
            Version = GetType().Assembly.GetName().Version.ToString();
        }
        public static LoginViewModel Create => new(null, null);
        public string Version { get; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public ObservableCollection<IFlexiConnection> Connections { get; set; } = new();
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            try
            {
                var connectionSettings = await _settingsStore.LoadAsync<ConnectionSettings>();

                foreach (var sett in connectionSettings.StandaloneSettings)
                    Connections.Add(sett);

                foreach (var sett in connectionSettings.ServerSettings)
                    Connections.Add(sett);
            }
            catch (Exception ex)
            {
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
                    await DialogService.ShowErrorAsync(ex);
                }

            });
        }

        public Task Close()
        {
            return TryCloseAsync();
        }

        public Task OpenConnectionSettings()
        {
            return DialogService.ShowDialogAsync(new ConnectionSettingsViewModel(_connectionFactory));
        }

    }
}
