using FlexiObject.API.Model;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;
using FlexiObject.Core.Repository.Database;

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
            return new Session(_container.Get<Application>(), _container.Get<IUserRepository>(), _container.Get<ICustomObjectRepository>());
        }

        public ISession CreateSession(string host, int port, string username, string password)
        {
            return new Session(_container.Get<Application>(), _container.Get<IUserRepository>(), _container.Get<ICustomObjectRepository>());
        }

        public void LogOff(ISession session)
        {
            session.Logoff();
        }
    }
}
