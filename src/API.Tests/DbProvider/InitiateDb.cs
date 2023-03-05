using FlexiObject.DbProvider;

using System;

using Xunit;

namespace FlexiObject.Tests.DbProvider
{
    public class InitiateDb : IDisposable
    {
        private readonly AppDbSettings _settings = new() { DbType = DbTypes.SqlLight, ServerName = "localhost", DatabaseName = "TestDb" };

        public InitiateDb()
        {
            SqlManager.RegisterManager(_settings);
        }
        [Fact]
        public void OpenConnection()
        {
            using ISqlConnectionItem connection = SqlManager.Register(Guid.NewGuid());
            connection.BeginTransaction();
            var ctx = connection.Context;
            ctx.ObjectDef.Add(new FlexiObject.DbProvider.Entities.ObjectDef
            {
                Id = 1,
                Created = DateTime.Now,
                FolderId = 0,
                UserDeletedById = 0
            });
            ctx.SaveChanges();
            connection.CommitTransaction();
            connection.Close();
        }

        public void Dispose()
        {

        }
    }
}
