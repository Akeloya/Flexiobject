using FlexiObject.API.Model;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;

namespace FlexiObject.AppServer.Repositories
{
    [Repository(typeof(ISessionRepository), typeof(ServerSessionRepository), true)]
    internal class ServerSessionRepository : ISessionRepository
    {
        private readonly IContainer _container;
        public ServerSessionRepository(IContainer container)
        {
            _container = container;
        }

        public ISession CreateSession(string host, int port)
        {
            return new Session(_container.Get<Application>());
        }

        public ISession CreateSession(string host, int port, string username, string password)
        {
            return new Session(_container.Get<Application>());
        }

        public void LogOff(ISession session)
        {
            session.Logoff();
        }
    }
}
