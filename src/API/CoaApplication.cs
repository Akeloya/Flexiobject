using FlexiObject.API.Settings;
using FlexiObject.API.Transport;
using FlexiObject.Core;

using Ninject;

using System;

namespace API
{
    public sealed class CoaApplication : Application, IDisposable
    {
        private readonly ApiBindings _bindings;
        private readonly IKernel _kernel;
        private readonly Client _client;
        public CoaApplication() : base()
        {
            _kernel = new StandardKernel();
            _bindings = new ApiBindings();
            _kernel.Load(_bindings);
            _client = (Client)_kernel.GetService(typeof(Client));
        }

        public override void WriteLogMessage(string msg)
        {
            _client.CallServer(msg);
        }

        protected override Session OnOpenSession(string host, int port)
        {
            _client.Open(host, port);
            return new CoaSession(this, _client);
        }

        protected override Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            _client.Open(host, port);
            return new CoaSession(this, _client);
        }

        public void Dispose()
        {
            //_bindings.Dispose();
            _kernel.Dispose();
        }
    }
}
