using System;
using System.Linq;
using Xunit;

namespace DbProvider.Test
{
    public class InitiateDb : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture _fixture;

        public InitiateDb(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }
        [Fact]
        public void OpenConnection()
        {
            using ISqlConnectionItem connection = SqlManager.Register(Guid.NewGuid());
            connection.BeginTransaction();
            var ctx = connection.Context;

            int objId = 1;

            for(int i = 0; i < 10; i++)
            {
                int folderId = i + 1;
                ctx.ObjectFolders.Add(new Entities.ObjectFolder
                {
                    Name = TestHelpers.GetRandName(),
                    Alias = TestHelpers.GetRandName(),
                    ParentId = int.MaxValue,
                    Id = folderId,
                });
                for(int j = 0; j < 100; j++)
                {
                    ctx.ObjectReport.Add(new Entities.ObjectDef
                    {
                        Id = objId++,
                        Created = DateTime.Now,
                        FolderId = folderId,
                        UserDeletedById = 0
                    });
                }
                ctx.SaveChanges();
            }
            
            ctx.SaveChanges();

            int countFolders = ctx.ObjectFolders.Count();
            Assert.Equal(10, countFolders);

            int countObj = ctx.ObjectReport.Count();
            Assert.Equal(1000, countObj);

            ctx.ObjectFolders.Remove(ctx.ObjectFolders.Where(x => x.Id == 1).Single());
            ctx.SaveChanges();

            countFolders = ctx.ObjectFolders.Count();
            Assert.Equal(9, countFolders);

            countObj = ctx.ObjectReport.Count();
            Assert.Equal(900, countObj);

            connection.CommitTransaction();
            connection.Close();
        }
    }
}
