using FlexiObject.AppClient.Core.Exceptions;
using FlexiObject.Core.Config;
using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Settings
{
    [JsonSettingSubFolder("Settings")]
    public class ConnectionSettings : AJsonSettings
    {
        public string SelectedSettings { get; set; }
        public bool StandaloneMode { get; set; }
        public List<AppServerSettings> ServerSettings { get; set; } = new();
        public List<StandaloneSettings> StandaloneSettings { get; set; } = new();
    }
    public interface IFlexiConnection
    {
        public string Name { get; set; }
        public Task SaveAsync();
    }

    public abstract class AFlexiConnection : IFlexiConnection
    {
        public string Name { get; set; } = "Новое подключение";

        public async Task SaveAsync()
        {
            if (!Validate())
                throw new InvalidOperationException();
            var jsonSettingsStore = ServiceLocator.Get<JsonSettingsStore>();
            var settings = await jsonSettingsStore.LoadAsync<ConnectionSettings>();
            Update(settings);
            await jsonSettingsStore.SaveAsync(settings);
        }
        protected abstract bool Validate();
        protected abstract void Update(ConnectionSettings settings);

    }
    public class AppServerSettings : AFlexiConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseWindows { get; set; }
        protected override void Update(ConnectionSettings settings)
        {
            settings.ServerSettings.RemoveAll(p => p.Name == Name);
            settings.ServerSettings.Add(this);
        }
        protected override bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Host) && Port != 0;
        }
    }

    public class StandaloneSettings : AFlexiConnection, IAppDbSettings
    {
        public DbTypes DbType { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        protected override void Update(ConnectionSettings settings)
        {
            settings.StandaloneSettings.RemoveAll(p => p.Name == Name);
            settings.StandaloneSettings.Add(this);
        }

        protected override bool Validate()
        {
            return !(string.IsNullOrWhiteSpace(ServerName) || string.IsNullOrEmpty(DatabaseName));
        }
    }

    public class FlexiConnectionFactory
    {
        private readonly JsonSettingsStore _jsonSettingsStore;
        public FlexiConnectionFactory(JsonSettingsStore jsonSettingsStore) 
        {
            _jsonSettingsStore = jsonSettingsStore;
        }
        public async Task<IReadOnlyCollection<IFlexiConnection>> GetConnections()
        {
            var settings = await _jsonSettingsStore.LoadAsync<ConnectionSettings>();

            var collection = settings.StandaloneSettings.OfType<IFlexiConnection>().Union(settings.ServerSettings);
            return collection.ToArray();
        }

        public IFlexiConnection Create(bool isStandalone)
        {
            return isStandalone ? new StandaloneSettings() : new AppServerSettings();
        }
    }

    public static class ConnectionEx
    {
        public static AppServerSettings GetServerSettings(this IFlexiConnection connection)
        {
            if (connection is not AppServerSettings)
                return null;
            return connection as AppServerSettings;
        }
        public static StandaloneSettings GetStandalone(this IFlexiConnection connection)
        {
            if (connection is not StandaloneSettings)
                return null;
            return connection as StandaloneSettings;
        }
    }
}
