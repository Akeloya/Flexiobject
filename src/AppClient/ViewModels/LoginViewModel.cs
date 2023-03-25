using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Settings;
using FlexiObject.Core.Config.SettingsStore;

using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IJsonSettingsStore _settingsStore;
        public LoginViewModel(IJsonSettingsStore jsonSettingsStore)
        {
            _settingsStore = jsonSettingsStore;
            Version = GetType().Assembly.GetName().Version.ToString();
        }
        public static LoginViewModel Create => new(null);
        public string Version { get; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool UseUserLogin { get; set; }
        public bool UseUserLoginIsVisible { get; set; } = false;

        public event EventHandler<bool> LoginCompleted;

        public ObservableCollection<IConnection> Connections { get; set; } = new();
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
            await Task.Run(() =>
            {
                try
                {
                    var app = ApiFactory.GetOrCreateApi().Create();

                    var session = app.OpenSession("localhost", 9696, null, null);
                    LoginCompleted?.Invoke(this, true);
                }
                catch (Exception ex)
                {
                    DialogService.ShowErrorAsync(ex);
                }

            });
        }

        public Task Close()
        {
            return TryCloseAsync();
        }

        public Task OpenConnectionSettings()
        {
            return Task.CompletedTask;
        }

    }
}
