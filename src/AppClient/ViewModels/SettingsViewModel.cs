using FlexiObject.API;
using FlexiObject.AppClient.Services;

namespace FlexiObject.AppClient.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public IJsonConfiguration _configuration;
        public SettingsViewModel(IJsonConfiguration jsonConfiguration, IDialogService dialogService, Api api): base(dialogService, api)
        {
            _configuration = jsonConfiguration;
        }
    }
}
