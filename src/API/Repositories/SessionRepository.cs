using FlexiObject.API.Transport;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;

namespace FlexiObject.API.Repositories
{
    internal class ClientSessionRepository : ISessionRepository
    {
        private readonly Client _client;
        private readonly IApplication _application;
        public ClientSessionRepository(IContainer container)
        {
            _client = container.Get<Client>();
            _application = container.Get<IApplication>();
        }

        public ISession CreateSession(string host, int port)
        {
            _client.Open(host, port);
            var result = _client.CallServer(_application, "OpenSession", host, port);
            if(result.Error!= null)
                throw result.Error;
            return result.Deserialize<ISession>();
        }

        public ISession CreateSession(string host, int port, string username, string password)
        {
            _client.Open(host, port);
            var result = _client.CallServer(_application, "OpenSession", host, port, username, password);
            if(result.Error!= null)
                throw result.Error;
            return result.Deserialize<ISession>();
        }

        public void LogOff(ISession session)
        {
            var result = _client.CallServer(session, "Logoff");
            if(result.Error!= null)
                throw result.Error;
        }
    }
}
