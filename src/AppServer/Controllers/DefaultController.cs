using EmbedIO.Routing;
using EmbedIO.WebApi;

using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Transport.DataContracts;
using FlexiObject.DbProvider;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Controllers
{
    internal class DefaultController : WebApiController
    {
        private readonly AppDbContext _context;
        private readonly JsonSettingsStore _jsonSettingsStore;
        private readonly ILogger _logger;
        public DefaultController(AppDbContext context, JsonSettingsStore jsonSettingsStore, LoggerFactory loggerFactory)
        {
            _context = context;
            _jsonSettingsStore = jsonSettingsStore;
            _logger = loggerFactory.Create<DefaultController>();
        }
        [Route(EmbedIO.HttpVerbs.Get, "/ping")]
        public Task<PingDataContract> Ping()
        {
            return Task.FromResult(new PingDataContract
            {
                DateTime = DateTime.Now,
                ServerInfo = "test server info",
                Version = "some version"
            });
        }

        [Route(EmbedIO.HttpVerbs.Post, "/createdb")]
        public async Task CreateDatabase()
        {
            try
            {
                var deleted = await _context.Database.EnsureDeletedAsync();
                _logger.Trace($"Deletion result: {deleted}, run migration");
                var created = await _context.Database.EnsureCreatedAsync();
                _logger.Trace($"Creation result: {created}, run migration");
                var migrations = _context.Database.GetPendingMigrations();
                _logger.Trace($"Pending migrations count: {migrations.Count()}");
                /*var sql = _context.Database.GenerateCreateScript();
                _logger.Debug(sql);
                if(migrations.Any())
                    await _context.Database.MigrateAsync();*/
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        [Route(EmbedIO.HttpVerbs.Get, "/connection")]
        public async Task<AppDbSettings> GetConnection()
        {
            var connection = await _jsonSettingsStore.LoadAsync<AppDbSettings>();
            connection.UserPassword = string.Empty;
            return connection;
        }
    }
}
