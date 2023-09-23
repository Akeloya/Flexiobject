using FlexiObject.Core.Interfaces;

using System.Collections.Generic;

namespace FlexiObject.AppServer.Repositories
{
    public interface IActiveSessionRepository
    {
        public IEnumerable<IActiveSession> GetActiveSessions(ISession requestor);
    }
}
