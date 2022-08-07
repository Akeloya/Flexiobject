using Flexiobject.API.Transport;
using Flexiobject.Core;
using Flexiobject.Core.Interfaces;

using System;

namespace API
{
    public class CoaSession : Session
    {
        private readonly Client _client;
        internal CoaSession(CoaApplication app, Client client): base(app)
        {
            _client = client;
        }

        public override IActiveSessions ActiveSessions => throw new NotImplementedException();

        public override void LogMessage(string msg)
        {
            _client.CallServer(msg);
        }

        public override void Logoff()
        {
            _client.CallServer(null);
        }
    }
}
