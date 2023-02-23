using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core.Repository
{
    public interface ISessionRepository
    {
        ISession CreateSession(string host, int port);
        ISession CreateSession(string host, int port, string username, string password);
        void LogOff(ISession session);
    }
}
