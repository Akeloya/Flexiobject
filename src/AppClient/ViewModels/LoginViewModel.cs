using FlexiObject.API;
using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Services;
using FlexiObject.Core.Config.SettingsStore;

using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IJsonSettingsStore _settingsStore;
        public LoginViewModel(IJsonSettingsStore jsonSettingsStore, IDialogService dialogService, Api api) : base(dialogService, api)
        {
            _settingsStore = jsonSettingsStore;
            Width = 1000;
            Height = 450;
        }
        public static LoginViewModel Create => new(null, null, null);
        public string Version { get; } = "some version";
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool UseUserLogin { get; set; }
        public bool UseUserLoginIsVisible { get; set; } = false;
        public Task DoLogin()
        {
            var app = Api.Create();
            app.OpenSession("localhost", 9696, null, null);
            return Task.CompletedTask;
        }

        public Task OpenConnectionSettings()
        {
            return Task.CompletedTask;
        }
    }
}
