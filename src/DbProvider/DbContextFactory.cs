using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

namespace FlexiOject.DbProvider
{
    public class DbContextFactory
    {
        private readonly JsonSettingsStore _jsonSettingsStore;
        public DbContextFactory(JsonSettingsStore jsonSettingsStore)
        {
            _jsonSettingsStore = jsonSettingsStore;
        }
        public AppDbContext Create()
        {
            var settings = _jsonSettingsStore.Load<AppDbSettings>();
            return new AppDbContext(settings);
        }
    }
}
