using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Transport;

using FlexiObject.AppServer.Settings;

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppServer.Services
{
    public class Server
    {
        private TcpListener _listener;
        private readonly ILogger _logger;
        private readonly JsonSettingsStore _jsonSettingsStore;
        private ServerSettings _serverSettings;
        private int _tcpClientCounter;
        private bool _serverStopped;
        private readonly static object _lock = new ();//remove
        private readonly LinkedList<TcpClient> _tcpClients = new();
        public Server(JsonSettingsStore jsonSettingsStore, LoggerFactory loggerFactory)
        {
            _jsonSettingsStore = jsonSettingsStore;


            _logger = loggerFactory.Create(nameof(Server));

        }

        public void Start()
        {
            _serverStopped = false;
            _serverSettings = _jsonSettingsStore.Load<ServerSettings>();
            _listener = new TcpListener(System.Net.IPAddress.Any, _serverSettings.Port);
            _listener.Start();
            _listener.BeginAcceptTcpClient(DoAcceptTcpListener, _listener);
            _logger.Info($"TCP listener started on port:{_serverSettings.Port}");
        }
        //TODO: Подумать над архитектурой приёма клиентов, обработкой запросов и привязкой к ActiveSession
        //Не дело, если транспорт будет что-то знать про объект IActiveSession,
        //С другой стороны IActiveSession не должен знать про реализацию транспорта.
        public Action<int> NewClientArrived { get; private set; }
        public Func<ExchangeMessage, int,Task> OnMessageRecieved { get; private set; }
        public void StartServerInBackground(Action<int> newClientArrived, Func<ExchangeMessage, int, Task> onMessageRecieved, CancellationToken token)
        {
            NewClientArrived = newClientArrived;
            OnMessageRecieved = onMessageRecieved;

            Task.Factory.StartNew(async () =>
            {
                _serverStopped = false;
                _serverSettings = await _jsonSettingsStore.LoadAsync<ServerSettings>();
                _listener = new TcpListener(System.Net.IPAddress.Any, _serverSettings.Port);
                _listener.Start();
                _logger.Info($"TCP listener started on port:{_serverSettings.Port}");
                while (!token.IsCancellationRequested && !_serverStopped)
                {
                    var tcpClient = await _listener.AcceptTcpClientAsync(token);
                    ProcessTcpClientInBackground(tcpClient, ++_tcpClientCounter, token);                    
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Stop()
        {
            _serverStopped = true;
            foreach (var client in _tcpClients)//TODO: send close to client app?
                client.Close();
            _listener.Stop();
            _logger.Info("TCP listener stopped");
        }

        private void DoAcceptTcpListener(IAsyncResult asyncResult)
        {
            if (_serverStopped)
                return;
            TcpListener listener = (TcpListener)asyncResult.AsyncState;
            _tcpClientCounter++;
            var clientNum = _tcpClientCounter;
            _logger.Info($"client {_tcpClientCounter} connected");
            using TcpClient tcpClient = listener.EndAcceptTcpClient(asyncResult);
            listener.BeginAcceptTcpClient(DoAcceptTcpListener, listener);

            using var stream = tcpClient.GetStream();
            var isProccessing = true;
            while (isProccessing)
            {
                if (stream.ReadData(out var msg))
                {
                    _logger.Info($"client {clientNum}: {msg.Method} {msg.MessageID}");
                    if (msg.Method == "Logoff")
                    {
                        lock (_lock)
                        {
                            stream.Write(Encoding.UTF8.GetBytes(msg.Serialize()));
                            isProccessing = false;
                        }
                        break;
                    }

                }
                Thread.Sleep(50);
            }
            stream.Close();
            tcpClient.Close();
        }

        private void ProcessTcpClientInBackground(TcpClient tcpClient, int clientNum, CancellationToken token)
        {
            _tcpClients.AddLast(tcpClient);
            NewClientArrived(clientNum);
            Task.Factory.StartNew(async () =>
            {
                using var stream = tcpClient.GetStream();
                var isProccessing = true;
                while (isProccessing && !token.IsCancellationRequested)
                {
                    var msg = await stream.ReadDataAsync(token);
                    if (msg != null)
                    {
                        msg.TimeRecieve = DateTime.Now;
                        _logger.Info($"client {clientNum}: {msg.Method} {msg.MessageID}");
                        try
                        {
                            await OnMessageRecieved(msg, clientNum);
                        }
                        catch(Exception ex)
                        {
                            _logger.Error(ex);
                            msg.Error = ex;
                        }

                        await stream.WriteAsync(Encoding.UTF8.GetBytes(msg.Serialize()));

                        if (msg.Method == "Logoff")
                        {
                            isProccessing = false;
                            break;
                        }

                    }
                    Thread.Sleep(50);
                }
                stream.Close();
                tcpClient.Close();
            }, TaskCreationOptions.LongRunning);
        }
    }
}
