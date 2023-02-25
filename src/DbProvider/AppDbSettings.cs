namespace FlexiObject.DbProvider
{
    public struct AppDbSettings
    {
        public DbTypes DbType { get; }
        public string ServerName { get; }
        public string DatabaseName { get; }
        public string UserName { get; }
        public string UserPassword { get; }

        public AppDbSettings(DbTypes type, string serverName, string dbName, string userName, string password)
        {
            DbType = type;
            ServerName = serverName;
            DatabaseName = dbName;
            UserName = userName;
            UserPassword = password;
        }
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
