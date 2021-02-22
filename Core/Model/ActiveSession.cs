using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    public abstract class ActiveSession : AppBase, IActiveSession
    {
        public string ClientType => throw new NotImplementedException();

        public string HostName => throw new NotImplementedException();

        public DateTime LoginTime => throw new NotImplementedException();

        public DateTime IdleTime => throw new NotImplementedException();

        public string UserName => throw new NotImplementedException();

        protected ActiveSession(Application app, object parent) : base(app, parent)
        {

        }
        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
