using FlexiObject.Core.Transport;

using FlexiObject.AppServer.Services;
using FlexiObject.AppServer.Settings;
using FlexiObject.Core;

using NLog;

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Model
{
    internal class CoaApplication: Application
    {
        private readonly Server _server;
        private readonly ILogger _logger;
        private readonly ObjectFactory _objectFactory;
        public CoaApplication(Server server, ObjectFactory objectFactory) : base()
        {
            _server = server;
            _objectFactory = objectFactory;
            _logger = LogManager.GetLogger(ServerLogSetup.UserLogName);
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
            if (msg.Data == null)
                throw new NotSupportedException();
            var type = Type.GetType(msg.ObjectType) ?? ByName(msg.ObjectType);
            var obj = _objectFactory.GetByType(type);
            var method = type.GetMethod(msg.Method);
            method.Invoke(obj, msg.Parameters);
            return Task.CompletedTask;
        }

        private static Type ByName(string name)
        {
            return
                AppDomain.CurrentDomain.GetAssemblies()
                    .Reverse()
                    .Select(assembly => assembly.GetType(name))
                    .FirstOrDefault(t => t != null)
                // Safely delete the following part
                // if you do not want fall back to first partial result
                ??
                AppDomain.CurrentDomain.GetAssemblies()
                    .Reverse()
                    .SelectMany(assembly => assembly.GetTypes())
                    .FirstOrDefault(t => t.Name.Contains(name));
        }
    }
}
