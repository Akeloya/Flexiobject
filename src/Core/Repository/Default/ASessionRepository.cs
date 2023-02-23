using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core.Repository.Default
{
    public class SessionRepository : ISessionRepository
    {
        protected readonly IContainer Container;
        public SessionRepository(IContainer container)
        {
            Container = container;
        }
        public virtual ISession CreateSession(string host, int port)
        {
            return new Session(Container.Get<Application>());
        }
        
        public virtual ISession CreateSession(string host, int port, string username, string password)
        {
            return new Session(Container.Get<Application>());
        }

        public virtual void LogOff(ISession session)
        {
            session.Logoff();
        }
    }
}
