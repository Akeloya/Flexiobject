using FlexiObject.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace FlexiObject.AppServer.Repositories
{
    public class ActiveSessionRepository : IActiveSessionRepository
    {
        public IEnumerable<IActiveSession> GetActiveSessions(ISession requestor)
        {
            throw new NotImplementedException();
        }
    }
}
