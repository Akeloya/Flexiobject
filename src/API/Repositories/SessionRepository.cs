using FlexiObject.API.Model;
using FlexiObject.API.Transport;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;
using FlexiObject.Core.Repository.Database;
using FlexiObject.Core.Transport.DataContracts;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.API.Repositories
{
    [Repository(typeof(ISessionRepository), typeof(ClientSessionRepository))]
    internal class ClientSessionRepository : ISessionRepository, IDisposable
    {
        private readonly Client _client;
        private readonly Application _application;
        private readonly IContainer _container;
        public ClientSessionRepository(IContainer container)
        {
            _container = container;
            _client = container.Get<Client>();
            _application = container.Get<Application>();
        }

        public ISession CreateSession(string host, int port)
        {
            Task.Run(async () =>
            {
                try
                {
                    await _client.Open(host, port);
                    var result = await _client.GetDataAsync<PingDataContract>("/api/OpenSession", new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token);
                }
                finally
                {
                    Dispose();
                }
                
            }).ConfigureAwait(false).GetAwaiter().GetResult();
            
            return new Session(_application, _container.Get<IUserRepository>(), _container.Get<ICustomObjectRepository>());
        }

        public ISession CreateSession(string host, int port, string username, string password)
        {
            Task.Run(async () =>
            {
                await _client.Open(host, port);
                var result = await _client.GetDataAsync<PingDataContract>("/api/OpenSession", new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token);
            }).ConfigureAwait(false).GetAwaiter().GetResult();

            return new Session(_application, _container.Get<IUserRepository>(), _container.Get<ICustomObjectRepository>());
        }

        public void LogOff(ISession session)
        {
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
