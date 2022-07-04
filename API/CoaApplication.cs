using Flexiobject.API.Transport;
using Flexiobject.Core;
using System;

namespace API
{
    public class CoaApplication : Application
    {        
        public CoaApplication() : base()
        {

        }

        protected override void OnLogMessage(string message)
        {
            throw new NotImplementedException();
        }

        protected override Session OnOpenSession(string host, int port)
        {
            var client = Client.Factory.GetSinglton();
            client.Open(host, port);
            return new CoaSession(this);
        }

        protected override Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
