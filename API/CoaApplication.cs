using CoaApp.Core;
using CoaApp.Core.Interfaces;
using System;

namespace API
{
    public class ClntApplication : CoaApplication
    {
        public ClntApplication()
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
