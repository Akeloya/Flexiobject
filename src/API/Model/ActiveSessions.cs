using FlexiObject.AppServer.Repositories;
using FlexiObject.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.API.Model.Model
{
    public class ActiveSessions : AppBase, IActiveSessions
    {
        private readonly Lazy<IReadOnlyList<IActiveSession>> _sessions;
        private readonly IActiveSessionRepository _activeSessionRepo;
        protected ActiveSessions(IApplication application, ISession parent, IActiveSessionRepository activeSessionRepo): base(application, parent)
        {
            _sessions = new Lazy<IReadOnlyList<IActiveSession>>(()=>_activeSessionRepo.GetActiveSessions(parent).ToArray());
            _activeSessionRepo = activeSessionRepo;
        }
        public IActiveSession this[int idx] => _sessions.Value[idx];
        public int Count => _sessions.Value.Count;
    }
}
