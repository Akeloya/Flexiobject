using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

namespace FlexiOject.DbProvider
{
    public class DbContextFactory
    {
        protected readonly JsonSettingsStore JsonSettingsStore;
        public DbContextFactory(JsonSettingsStore jsonSettingsStore)
        {
            JsonSettingsStore = jsonSettingsStore;
        }
        public virtual AppDbContext Create()
        {
            var settings = JsonSettingsStore.Load<AppDbSettings>();
            return Create(settings);
        }

        public AppDbContext Create(IAppDbSettings settings)
        {
            return new AppDbContext(settings);
        }
    }
}
