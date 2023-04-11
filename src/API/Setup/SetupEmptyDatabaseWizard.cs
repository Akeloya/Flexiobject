using FlexiObject.Core.Wizard;
using FlexiObject.DbProvider;
using FlexiObject.DbProvider.Entities;

using NLog;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.API.Setup
{
    //TODO: переделать в посетителя/цепочку обязанностей/компановщика, чтобы не плодить портянку, а раскидать по отдельным классам, отвечающим каждый за своё
    //Создать БД -> создать пользователей -> создать пользовательские папки с полями для управления пользователями -> связать папки с AppUsers.
    public class SetupEmptyDatabaseWizardStep : IWizardStep
    {
        private readonly AppDbContextFactory _appDbContextFactory;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public SetupEmptyDatabaseWizardStep(AppDbContextFactory dbContextFactory)
        {
            _appDbContextFactory = dbContextFactory;
        }
        public string Name => "Setup empty database";

        public bool IsBackground => false;

        public Delegate OnProgressChanged;
        public async Task SetupAsync()
        {
            var dbContext = _appDbContextFactory.CreateDbContext();

            var dbCreated = await dbContext.Database.EnsureCreatedAsync();

            await using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                await dbContext.AppUsers.AddRangeAsync(GetDefaultUsers());
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                try
                {
                    await transaction.RollbackAsync();
                }
                catch (Exception ex2)
                {
                    Logger.Error(ex2);
                }

                throw;
            }
        }

        private IEnumerable<AppUser> GetDefaultUsers()
        {
            var users = new LinkedList<AppUser>();
            users.AddLast(new AppUser()
            {
                LoginName = "FlexiAdmin",
                Password = "FlexiAdmin",
                IsGroup = false,
                IsAdministrator = true,
                IsActive = true,
                LoginMode = Core.Enumes.FlexiUserAuthTypes.Internal
            });
            users.AddLast(new AppUser()
            {
                LoginName = "FlexiUser",
                Password = "FlexiUser",
                IsGroup = false,
                IsAdministrator = false,
                IsActive = true,
                LoginMode = Core.Enumes.FlexiUserAuthTypes.Internal
            });
            return users;
        }
    }
}
