using Flexiobject.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flexiobject.AppServer.Model
{
    internal class CoaApplication: Application
    {
        internal CoaApplication() : base()
        {

        }

        protected override void OnLogMessage(string message)
        {
            throw new NotImplementedException();
        }

        protected override Session OnOpenSession(string host, int port)
        {
            throw new NotImplementedException();
        }

        protected override Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
