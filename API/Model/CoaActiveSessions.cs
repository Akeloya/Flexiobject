using API;

using FlexiObject.Core.Model;

using FlexiObject.Core.Interfaces;

using System;
using System.Collections.Generic;

namespace FlexiObject.API.Model
{
    internal class CoaActiveSessions : ActiveSessions
    {
        internal CoaActiveSessions(CoaApplication app, ISession parent) : base(app, parent)
        {

        }

        protected override IReadOnlyList<IActiveSession> GetActiveSessions()
        {
            throw new NotImplementedException();
        }
    }
}
