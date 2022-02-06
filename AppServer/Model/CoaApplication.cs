using CoaApp.Core;
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServer.Model
{
    internal class SrvApplication: CoaApplication
    {
        internal SrvApplication()
        {

        }

        protected override void OnLogMessage(string message)
        {
            throw new NotImplementedException();
        }

        protected override ISession OnOpenSession(string host, int port)
        {
            throw new NotImplementedException();
        }

        protected override ISession OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
