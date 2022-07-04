using CoaApp.Core.Config;
using CoaApp.Core.Logging;
using CoaApp.Core.Transport;

using Flexiobject.AppServer.Settings;

using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Flexiobject.AppServer.Services
{
    public class Server
    {
        private TcpListener _listener;
        private readonly ILogger _logger;
        private readonly JsonSettingsStore _jsonSettingsStore;
        private ServerSettings _serverSettings;
        private int _tcpClientCounter;

        private readonly static object _lock = new object();//remove
        public Server(JsonSettingsStore jsonSettingsStore, LoggerFactory loggerFactory)
        {
            _jsonSettingsStore = jsonSettingsStore;


            _logger = loggerFactory.Create(nameof(Server));

        }

        public void Start()
        {
            _serverSettings = _jsonSettingsStore.Load<ServerSettings>();
            _listener = new TcpListener(System.Net.IPAddress.Any, _serverSettings.Port);
            _listener.Start();
            _listener.BeginAcceptTcpClient(DoAcceptTcpListener, _listener);
            _logger.Info($"TCP listener started on port:{_serverSettings.Port}");
        }

        public void Stop()
        {
            _listener.Stop();
            _logger.Info("TCP listener stopped");
        }

        private void DoAcceptTcpListener(IAsyncResult asyncResult)
        {
            TcpListener listener = (TcpListener)asyncResult.AsyncState;

            _tcpClientCounter++;
            var clientNum = _tcpClientCounter;
            _logger.Info($"client {_tcpClientCounter} connected");
            using TcpClient tcpClient = _listener.EndAcceptTcpClient(asyncResult);
            listener.BeginAcceptTcpClient(DoAcceptTcpListener, listener);

            using var stream = tcpClient.GetStream();
            var isProccessing = true;
            while (isProccessing)
            {
                if (stream.CanRead)
                {
                    var memory = new byte[1024];
                    var reads = 0;
                    lock (_lock)
                    {
                        reads = stream.Read(memory, 0, 1024);                        
                    }
                    if (reads > 0)
                    {
                        var data = memory.AsSpan(0, reads);
                        var msgString = Encoding.UTF8.GetString(data);
                        var msg = msgString.Deserialize();
                        _logger.Info($"client {clientNum}: {msg.Method} {msg.MessageID}");
                        if (msg.Method == "Logoff")
                        {
                            lock (_lock)
                            {
                                stream.Write(data);
                                //stream.Flush();
                                isProccessing = false;
                            }
                            break;
                        }
                    }

                }
                Thread.Sleep(500);
            }
            stream.Close();
            tcpClient.Close();
        }
    }
}
