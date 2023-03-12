using FlexiObject.Core.Logging;
using FlexiObject.DbProvider;

using System;

namespace FlexiOject.DbProvider
{
    public class BaseDbRepository
    {
        protected readonly AppDbContext _appDbContext;
        private readonly ILogger _logger;
        public BaseDbRepository(AppDbContext context, LoggerFactory loggerFactory)
        {
            _appDbContext = context;
            _logger = loggerFactory.Create<BaseDbRepository>();
        }

        protected void ExecuteInTransaction(Action action)
        {
            var transactionRolledBack = false;
            try
            {
                _appDbContext.Database.BeginTransaction();
                action();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                try
                {
                    _appDbContext.Database.RollbackTransaction();
                    transactionRolledBack = true;
                }
                catch(Exception ex2)
                {
                    _logger.Error(ex2);
                }
                throw;
            }
            finally
            {
                if(!transactionRolledBack)
                    _appDbContext.Database.CommitTransaction();
            }
        }
    }
}
