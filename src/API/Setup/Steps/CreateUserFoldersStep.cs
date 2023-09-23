using FlexiObject.DbProvider;
using FlexiObject.DbProvider.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

namespace FlexiObject.API.Setup.Steps
{
    internal class CreateUserFoldersStep : BaseSetupDbStep
    {
        public CreateUserFoldersStep(AppDbContext appDbContext) : base("Create user folders", appDbContext)
        {

        }

        public override async Task SetupAsync()
        {
            var folder = await AppDbContext.ObjectFolders.AddAsync(new ObjectFolder
            {
                Name = "Пользователи и группы",
                Alias = "Users and groups",
                ParentId = int.MaxValue,
                
            });
            await AppDbContext.SaveChangesAsync();
            var userFolder = await CreateUserFolderAsync(folder.Entity);
            await CreateUserFieldsAsync(userFolder);

            var groupFolder = await CreateGroupFolderAsync(folder.Entity);
            await CreateGroupFieldsAsync(groupFolder);
        }

        private async Task<ObjectFolder> CreateUserFolderAsync(ObjectFolder folder)
        {
            var result = await AppDbContext.ObjectFolders.AddAsync(new ObjectFolder
            {
                Name = "Пользователи",
                Alias = "Users",
                Parent = folder
            });

            await AppDbContext.SaveChangesAsync();

            return result.Entity;
        }

        private async Task<ObjectFolder> CreateGroupFolderAsync(ObjectFolder folder)
        {
            var result = await AppDbContext.ObjectFolders.AddAsync(new ObjectFolder
            {
                Name = "Группы безопасности",
                Alias = "Groups",
                Parent = folder
            });
            await AppDbContext.SaveChangesAsync();

            await AppDbContext.AppTableDefinitions.AddAsync(new SchemeTableDefinition
            {
                Id = folder.Id,
                TableName = $"UserTable{folder.Id}",
                Deleted = false
            });

            await AppDbContext.Database.ExecuteSqlRawAsync($"CREATE TABLE UserTable{folder.Id} " +
                $"(UniqueId BIGINT PRIMARY KEY)");

            await AppDbContext.SaveChangesAsync();

            return result.Entity;
        }

        private async Task CreateUserFieldsAsync(ObjectFolder folder)
        {
            await AppDbContext.SaveChangesAsync();
        }

        private async Task CreateGroupFieldsAsync(ObjectFolder folder)
        {
            await AppDbContext.SaveChangesAsync();
        }
    }
}
