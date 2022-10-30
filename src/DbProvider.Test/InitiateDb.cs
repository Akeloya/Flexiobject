using System;
using FlexiObject.DbProvider;
using Xunit;

namespace Flexiobject.DbProvider.Test
{
    public class InitiateDb : IDisposable
    {
        AppDbSettings _settings = new AppDbSettings(DbTypes.SqlLight, "localhost", "TestDb",null,null);

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
            ctx.ObjectReport.Add(new FlexiObject.DbProvider.Entities.ObjectDef
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
