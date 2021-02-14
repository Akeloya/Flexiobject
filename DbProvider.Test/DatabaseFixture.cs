using System;

namespace DbProvider.Test
{
    public class DatabaseFixture : IDisposable
    {
        AppDbSettings _settings = new AppDbSettings(DbTypes.SqlLight, "localhost", "TestDb", null, null);

        public AppDbSettings Settings => _settings;
        public DatabaseFixture()
        {
            SqlManager.RegisterManager(_settings);
        }
        public void Dispose()
        {
            
        }
    }
}
