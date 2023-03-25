using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Services;

namespace FlexiObject.AppClient.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public IJsonConfiguration _configuration;
        public SettingsViewModel(IJsonConfiguration jsonConfiguration)
        {
            _configuration = jsonConfiguration;
        }
    }
}
