using FlexiObject.Core.Transport;

using FlexiObject.AppServer.Services;
using FlexiObject.AppServer.Settings;

using NLog;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FlexiObject.Core.Interfaces;
using System.Reflection;

namespace FlexiObject.AppServer.Model
{
    internal class Server
    {
        private readonly ConnectionServer _server;
        private readonly ILogger _logger;
        private readonly ObjectFactory _objectFactory;
        public Server(ConnectionServer server, ObjectFactory objectFactory)
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

        private void NewClientArrived(int clientNum)
        {
            _logger.Info($"Client connected: {clientNum}");
        }

        private Task OnMessageRecievedAsync(ExchangeMessage msg, int clientId)
        {
            //Сюда прилетел тип с FlexiObject.API, но его в домене нет.
            //Необходимо либо маршрутизировать типы до базовых интерфейсов и на клиентской части и тут
            //Чтобы они корректно парсились и объекты корректно подставлялись.
            if (msg.Data == null)
                throw new NotSupportedException();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(p=> p.FullName.Contains("FlexiObject")).SelectMany(p=> p.DefinedTypes);
            var type = assemblies.FirstOrDefault(p=> p.FullName == msg.ObjectType);
            if(type == null)
                throw new NotSupportedException();
            //var type = Type.GetType(msg.ObjectType);
            object obj;
            if(type.GetInterfaces().Contains(typeof(IApplication)))
                obj = _objectFactory.GetByType(typeof(IApplication));
            else
                obj = msg.DeserializeData(type);
            var method = type.GetMethod(msg.Method);
            method.Invoke(obj, msg.Parameters);
            return Task.CompletedTask;
        }
    }
}
