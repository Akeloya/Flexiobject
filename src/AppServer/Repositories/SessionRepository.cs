using FlexiObject.Core;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Default;

namespace FlexiObject.AppServer.Repositories
{
    internal class ServerSessionRepository : SessionRepository
    {
        public ServerSessionRepository(IContainer container) : base(container)
        {
        }

        public override ISession CreateSession(string host, int port)
        {
            return new Session(Container.Get<Application>());
        }

        public override ISession CreateSession(string host, int port, string username, string password)
        {
            return new Session(Container.Get<Application>());
        }

        public override void LogOff(ISession session)
        {
            session.Logoff();
        }
    }
}
