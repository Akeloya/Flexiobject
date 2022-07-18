using CoaApp.Core.Transport;

using Flexiobject.AppServer.Services;
using Flexiobject.Core;

using NLog;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Flexiobject.AppServer.Model
{
    internal class CoaApplication: Application
    {
        private readonly Server _server;
        private readonly ILogger _logger;
        public CoaApplication(Server server) : base()
        {
            _server = server;
            _logger = LogManager.GetLogger("userLogging");
        }

        public void Start(CancellationToken token)
        {
            _server.StartServerInBackground(NewClientArrived, OnMessageRecievedAsync, token);
        }

        public void Stop()
        {
            _server.Stop();
        }
        public override void WriteLogMessage(string message)
        {
            _logger.Info(message);
        }

        protected override Session OnOpenSession(string host, int port)
        {
            throw new NotImplementedException();
        }

        protected override Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            throw new NotImplementedException();
        }

        private void NewClientArrived(int clientNum)
        {
            
        }

        private Task OnMessageRecievedAsync(ExchangeMessage msg, int clientId)
        {
            return Task.CompletedTask;
        }
    }
}
