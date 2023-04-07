using FlexiObject.API.Settings;
using FlexiObject.DbProvider;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels.Connection
{
    internal class StandaloneSettingsViewModel : ASettingsViewModel
    {
        public StandaloneSettingsViewModel(IFlexiConnection connection)
        {
            Settings = connection as StandaloneSettings ?? new StandaloneSettings();
            Discard();
        }
        public StandaloneSettings Settings { get; }

        public string Name { get; set; }
        public IReadOnlyCollection<DbTypes> DatabaseTypes { get; } = Enum.GetValues(typeof(DbTypes)).OfType<DbTypes>().ToArray();
        public DbTypes DbType { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public override void Apply()
        {
            Settings.Name = Name;
            Settings.DatabaseName = DatabaseName;
            Settings.UserName = UserName;
            Settings.DbType = DbType;
            Settings.ServerName = ServerName;
            Settings.UserName = UserName;
            Settings.UserPassword = UserPassword;
        }

        public override async Task ApplyAsync()
        {
            Apply();
            await Settings.SaveAsync();
        }
        public override void Discard()
        {
            Name = Settings.Name;
            DbType = Settings.DbType;
            ServerName = Settings.ServerName;
            DatabaseName = Settings.DatabaseName;
            UserName = Settings.UserName;
            UserPassword = Settings.UserName;
        }
    }
}
