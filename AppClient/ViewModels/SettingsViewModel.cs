using FlexiObject.AppClient.Services;

namespace FlexiObject.AppClient.ViewModels
{
    public class SettingsViewModel
    {
        public IJsonConfiguration _configuration;
        public SettingsViewModel(IJsonConfiguration jsonConfiguration)
        {
            _configuration = jsonConfiguration;
        }
    }
}
