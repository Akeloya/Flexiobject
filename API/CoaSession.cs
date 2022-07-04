using Flexiobject.API.Transport;
using Flexiobject.Core;
using Flexiobject.Core.Interfaces;

using System;

namespace API
{
    public class CoaSession : Session
    {
        internal CoaSession(CoaApplication app): base(app)
        {

        }

        public override IActiveSessions ActiveSessions => throw new NotImplementedException();

        public override void LogMessage(string msg)
        {
            var client = Client.Factory.GetSinglton();
            client.CallServer(msg);
        }

        public override void Logoff()
        {
            var client = Client.Factory.GetSinglton();
            client.CallServer(null);
        }
    }
}
