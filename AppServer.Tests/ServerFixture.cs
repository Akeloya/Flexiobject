using AppServer.Model;
using CoaApp.Core;
using CoaApp.Core.Interfaces;
using System;

namespace AppServerTests
{
    public class ServerFixture : IDisposable
    {
        private bool _disposed;
        public CoaApplication Application { get; }
        public ServerFixture()
        {
            Application = new CoaApplication();
        }
        ~ServerFixture()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ISession GetSession()
        {
            return Application.OpenSession(null, 0, null, null);
        }
        public void Dispose()
        {
            Dispose(false);
        }

        protected virtual void Dispose(Boolean disposing)
        {
            if (_disposed)
                return;
            if(disposing)
            {
                
            }
            _disposed = true;
        }
    }
}
