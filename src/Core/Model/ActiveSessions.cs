using FlexiObject.Core;
using FlexiObject.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlexiObject.Core.Model
{
    public abstract class ActiveSessions : AppBase<ISession>, IActiveSessions
    {
        private readonly Lazy<IReadOnlyList<IActiveSession>> _sessions;
        protected ActiveSessions(Application application, ISession parent): base(application, parent)
        {
            _sessions = new Lazy<IReadOnlyList<IActiveSession>>(() => GetActiveSessions());
        }
        [JsonIgnore]
        public IActiveSession this[int idx] => _sessions.Value[idx];
        [JsonIgnore]
        public int Count => _sessions.Value.Count;

        protected abstract IReadOnlyList<IActiveSession> GetActiveSessions();
    }
}
