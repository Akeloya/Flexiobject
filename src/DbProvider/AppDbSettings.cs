using FlexiObject.Core.Config;

namespace FlexiObject.DbProvider
{
    [JsonSettingSubFolder("Settings")]
    public class AppDbSettings : AJsonSettings
    {
        public DbTypes DbType { get; set; } = DbTypes.Memory;
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
