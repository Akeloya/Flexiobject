using FlexiObject.API.Transport;
using FlexiObject.Core;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Default;

namespace FlexiObject.API.Repositories
{
    internal class ClientSessionRepository : SessionRepository
    {
        private readonly Client _client;
        private readonly Application _application;
        public ClientSessionRepository(IContainer container) : base(container)
        {
            _client = container.Get<Client>();
            _application = container.Get<Application>();
        }

        public override ISession CreateSession(string host, int port)
        {
            _client.Open(host, port);
            var result = _client.CallServer(_application, "OpenSession", host, port);
            if(result.Error!= null)
                throw result.Error;
            return result.Deserialize<ISession>();
        }

        public override ISession CreateSession(string host, int port, string username, string password)
        {
            var result = _client.CallServer(_application, "OpenSession", host, port, username, password);
            if(result.Error!= null)
                throw result.Error;
            return result.Deserialize<ISession>();
        }

        public override void LogOff(ISession session)
        {
            var result = _client.CallServer(session, "Logoff");
            if(result.Error!= null)
                throw result.Error;
        }
    }
}
