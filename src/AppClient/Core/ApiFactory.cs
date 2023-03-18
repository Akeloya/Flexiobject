using FlexiObject.API;
using FlexiObject.AppClient.Core.Settings;
using FlexiObject.Core.Config.SettingsStore;

using System;

namespace FlexiObject.AppClient.Core
{
    public class ApiFactory : IDisposable
    {
        private static Api _api;
        private readonly IJsonSettingsStore _settingsStore;
        public ApiFactory(IJsonSettingsStore settingsStore)
        {
            _settingsStore = settingsStore;
        }
        public Api GetOrCreateApi()
        {
            if (_api != null)
                return _api;

            var settings = _settingsStore.Load<AppSettings>();
            _api = new Api(settings.GetCurrent().IsStandalone);
            return _api;
        }

        public void ResetApi()
        {
            _api?.Dispose();
            _api = null;
        }

        public void Dispose()
        {
            _api?.Dispose();
        }
    }
}
