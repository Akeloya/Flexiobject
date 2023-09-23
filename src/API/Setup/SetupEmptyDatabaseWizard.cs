using FlexiObject.API.Setup.Steps;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Wizard;
using FlexiObject.DbProvider;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.API.Setup
{
    public class SetupEmptyDatabaseWizardStep : IWizardStep
    {
        private readonly AppDbContextFactory _appDbContextFactory;
        private readonly ILogger _logger;
        private readonly LoggerFactory _loggerFactory;
        public SetupEmptyDatabaseWizardStep(AppDbContextFactory dbContextFactory, LoggerFactory loggerFactory)
        {
            _appDbContextFactory = dbContextFactory;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.Create<SetupEmptyDatabaseWizardStep>();
        }
        public string Name => "Setup empty database";

        public bool IsBackground => false;

        public Delegate OnProgressChanged;
        public async Task SetupAsync()
        {
            var dbContext = _appDbContextFactory.CreateDbContext();

            var steps = new List<IWizardStep>()
            {
                new CreateUserFoldersStep(dbContext),
                new AddUsersStep(dbContext)
            };
            //TODO: add building empty database for any saved schema to create different examples for users
            
            var dbCreated = await dbContext.Database.EnsureCreatedAsync();
            await using var transaction = await dbContext.Database.BeginTransactionAsync();

            try
            {
                var wizardExecutor = new WizardExecutor(steps,_loggerFactory);
                await wizardExecutor.SetupAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                try
                {
                    await transaction.RollbackAsync();
                }
                catch (Exception ex2)
                {
                    _logger.Error(ex2);
                }

                throw;
            }
        }        
    }
}
