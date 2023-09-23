using FlexiObject.Core.Config.SettingsStore;
using FlexiObject.DbProvider;

using FlexiOject.DbProvider;

namespace FlexiObject.API.Settings
{
    public class StandaloneDbContextFactory : DbContextFactory
    {
        public StandaloneDbContextFactory(JsonSettingsStore jsonSettingsStore) : base(jsonSettingsStore)
        {
        }

        public override AppDbContext Create()
        {
            var connectionSettings = JsonSettingsStore.Load<ConnectionSettings>();
            var settings = connectionSettings.GetCurrent();
            if (settings.IsStandalone)
                return Create(settings as IAppDbSettings);
            return base.Create();
        }
    }
}
