using FlexiObject.Core.Config.SettingsStore;

namespace FlexiObject.DbProvider
{
    public interface IAppDbSettings
    {
        DbTypes DbType { get; set; }
        string ServerName { get; set; }
        string DatabaseName { get; set; }
        string UserName { get; set; }
        string UserPassword { get; set; }
    }
    [JsonSettingSubFolder("Settings")]
    public class AppDbSettings : AJsonSettings, IAppDbSettings
    {
        public DbTypes DbType { get; set; } = DbTypes.SqlLight;
        public string ServerName { get; set; } = "localhost";
        public string DatabaseName { get; set; } = "FlexiObjectDatabase";
        public string UserName { get; set; } = "FlexiObject_User";
        public string UserPassword { get; set; }
    }

    public enum DbTypes
    {
        Files,
        Memory,
        MsJet,
        MsSqlServer,
        MySql,
        Oracle,
        PostgreSql,
        SqlLight
    }
}
