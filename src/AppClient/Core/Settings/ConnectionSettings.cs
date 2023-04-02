using FlexiObject.Core.Config;
using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

using System;
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

        private IEnumerable<IFlexiConnection> LoginSettings => ServerSettings.OfType<IFlexiConnection>().Union(StandaloneSettings);
        public IFlexiConnection GetCurrent()
        {
            if (!LoginSettings.Any())
                throw new Exception("Нет настроек подключения");

            if (string.IsNullOrWhiteSpace(SelectedSettings))
            {
                throw new Exception("Не выбраны настройки подключения");
            }
            var selectedSettings = LoginSettings.First(p => p.Name == SelectedSettings);

            if (selectedSettings == null)
            {
                if (LoginSettings.Count() > 0)
                    SelectedSettings = null;
                else
                {
                    throw new Exception("Некорректные настройки подключения");
                }
            }
            return selectedSettings;
        }
    }
    public interface IFlexiConnection
    {
        public string Name { get; set; }
        public bool IsStandalone { get; }
        public string BuildInfo();
        public Task SaveAsync();
    }

    public abstract class AFlexiConnection : IFlexiConnection
    {
        protected string _oldName;
        protected string _newName;
        public string Name
        {
            get
            {
                return _newName;
            }
            set
            {
                if (_newName == value)
                    return;
                _oldName = _newName;
                _newName = value;
            }
        }

        protected bool NameChanged => string.CompareOrdinal(_oldName, _newName) != 0;

        public virtual bool IsStandalone { get; private set; }

        public async Task SaveAsync()
        {
            if (!Validate())
                throw new Exceptions.InvalidOperationException();
            var jsonSettingsStore = ServiceLocator.Get<JsonSettingsStore>();
            var settings = await jsonSettingsStore.LoadAsync<ConnectionSettings>();
            Update(settings);
            await jsonSettingsStore.SaveAsync(settings);
        }
        protected abstract bool Validate();
        protected abstract void Update(ConnectionSettings settings);

        public abstract string BuildInfo();
    }
    public class AppServerSettings : AFlexiConnection
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseWindows { get; set; }

        public override string BuildInfo()
        {
            return $"{Host}:{Port}";
        }

        protected override void Update(ConnectionSettings settings)
        {
            if (settings.StandaloneSettings.Any(p => p.Name == Name))
                throw new FlexiObject.Core.Exceptions.ApplicationException();
            settings.ServerSettings.RemoveAll(p => (NameChanged ? _oldName : Name) == p.Name);
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
        public override bool IsStandalone => true;

        public override string BuildInfo()
        {
            return $"ServerName={ServerName}, CatalogName={DatabaseName}, User ID={UserName}";
        }

        protected override void Update(ConnectionSettings settings)
        {
            if (settings.ServerSettings.Any(p => p.Name == Name))
                throw new FlexiObject.Core.Exceptions.ApplicationException();
            settings.StandaloneSettings.RemoveAll(p => (NameChanged ? _oldName : Name) == p.Name);
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

        public static async Task RemoveThis(this IFlexiConnection connection)
        {
            var store = ServiceLocator.Get<JsonSettingsStore>();
            var settings = await store.LoadAsync<ConnectionSettings>();
            settings.StandaloneSettings.RemoveAll(p => p.Name == connection.Name);
            settings.ServerSettings.RemoveAll(p => p.Name == connection.Name);
            await store.SaveAsync(settings);
        }
    }
}
