using CoaApp.Core.Transport;

using NLog;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flexiobject.API.Transport
{
    /// <summary>
    /// Клиентская реализация общения с сервером.
    /// Отправляем сообщение и засыпаем до наступления таймаута.
    /// В бэкграунде поток ловит сообщения от сервера. Если сообщение есть в куче - обновляет его и вызывает синхронизацию с заснувшим потоком,
    /// чтобы он забрал сообщение из кучи и отдал ответ.
    /// </summary>
    class Client : IDisposable
    {
        private static readonly object _lockObject = new();
        private readonly Guid _clientUid = Guid.NewGuid();
        private readonly ConcurrentDictionary<Guid, ExchangeMessage> _sendedMessages = new();
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger _logger;
        private TcpClient _client;
        private NetworkStream _stream;
        private Task _backgroundReader;
        
        internal static ClientFactory Factory { get; }
        static Client()
        {
            Factory = new ClientFactory();
        }
        public Client()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void Open(string hostName, int port)
        {
            try
            {
                _client = new TcpClient(hostName, port);
                _stream = _client.GetStream();
                _backgroundReader = ReadDataFromServerAsync(_cancellationTokenSource.Token);
                //_backgroundReader.Start(Task.Factory.Scheduler);
            }
            catch (SocketException ex)
            {
                _logger.Error(ex);
                switch (ex.SocketErrorCode)
                {
                    case SocketError.ConnectionRefused:
                    case SocketError.ConnectionAborted:
                        //TODO: log error later
                        throw;
                }
                throw;
            }

            _stream = _client.GetStream();
        }

        public Task<ExchangeMessage> CallServerAsync(object data, [CallerMemberName] string method = null, params object[] parameters)
        {
            return Task.Factory.StartNew(() =>
            {
                return CallServer(data, 60, method, parameters);
            });
        }
        public Task<ExchangeMessage> CallServerAsync(object data, int timeOutInSec, [CallerMemberName] string method = null, params object[] parameters)
        {
            return Task.Factory.StartNew(() =>
            {
                return CallServer(data, timeOutInSec, method, parameters);
            });
        }
        public ExchangeMessage CallServer(object data, [CallerMemberName] string method = null, params object[] parameters)
        {
            return CallServer(data, 60, method, parameters);
        }
        public ExchangeMessage CallServer(object data, int timeOutInSec, [CallerMemberName] string method = null, params object[] parameters)
        {
            var msg = new ExchangeMessage
            {
                ClientUid = _clientUid,
                TimeSend = DateTime.Now,
                Method = method,
                Data = data,
                Parameters = parameters,
                ThreadId = Environment.CurrentManagedThreadId
            };
            var sendingJson = msg.Serialize();
            var sendData = Encoding.UTF8.GetBytes(sendingJson);
            try
            {
                var prm = msg.Parameters?.Aggregate(string.Empty, (current, parameter) => current + ((parameter ?? "null") + ","));
                if (prm?.Length > 1)
                    prm = prm.Remove(prm.Length - 1);
                _logger.Debug(prm);

                if (_sendedMessages.TryAdd(msg.MessageID, msg))
                {
                    lock (_lockObject)
                    {
                        _stream.Write(sendData, 0, sendData.Length); //передали данные
                        _stream.Flush();
                        msg.SyncObj = new ManualResetEvent(false);
                    }
                }
                else
                {
                    _logger.Error("Cannot add message to queue");
                    //TODO: log, and? think...
                    throw new InvalidOperationException();
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                msg.Error = e;
                throw;
            }
            lock (msg.SyncObj)
            {
                //TODO: check recieve time before wait
                if (!msg.SyncObj.WaitOne(timeOutInSec * 1000))
                {
                    _sendedMessages.TryRemove(msg.MessageID, out _);
                    throw new TimeoutException();
                }
            }
            return msg;
        }

        private async Task ReadDataFromServerAsync(CancellationToken token)
        {
            bool closeFromServer = false;
            while (!token.IsCancellationRequested && !closeFromServer)
            {
                try
                {
                    var msg = await _stream.ReadDataAsync(token);
                    if (msg == null)
                    {
                        await Task.Delay(100, token);
                        continue;
                    }
                    var prm = msg.Parameters?.Aggregate(string.Empty, (current, parameter) => current + (parameter ?? "null") + ",");
                    if (prm?.Length > 1)
                        prm = prm.Remove(prm.Length - 1);
                    _logger.Debug(prm);

                    if (!_sendedMessages.TryGetValue(msg.MessageID, out var sendedMsg))
                    {
                        _logger.Debug("No message! Time out?");
                        //TODO: log, here no message because of timeout
                        continue;
                    }
                    sendedMsg.Data = msg.Data;
                    sendedMsg.Error = msg.Error;
                    sendedMsg.TimeRecieve = DateTime.Now;
                    sendedMsg.SyncObj.Set();

                    switch (msg.Method)
                    {
                        case "NotifyServer":
                            {
                                try
                                {
                                    GetMessage?.BeginInvoke(this, (ApiMessageDataContract)msg.Data, x => { }, null);
                                }
                                catch(Exception ex)
                                {
                                    _logger.Error(ex);
                                    //TODO: log error
                                }
                            }
                            break;
                        case "Logoff":
                            {
                                closeFromServer = true;
                                try
                                {
                                    Closing?.Invoke(this, null);
                                }
                                catch(Exception ex)
                                {
                                    _logger.Error(ex);
                                    //TODO: log error
                                }
                            }
                            break;
                    }
                }
                catch (IOException e)
                {
                    _logger.Error(e);
                    try
                    {
                        OnErrorRaised?.Invoke(this, e);
                    }
                    catch(Exception ex)
                    {
                        _logger.Error(ex);
                        //supress errors
                    }
                    continue;//TODO: Требуется более корректная обработка ошибки, возможно со счётчиком ошибочных чтений...
                }
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Dispose();
        }

        public event EventHandler<Exception> OnErrorRaised;
        public event EventHandler<ApiMessageDataContract> GetMessage;
        public event EventHandler Closing;
    }

    internal class SendedMessage
    {
        public ExchangeMessage Message { get; set; }
        public string Method { get; set; }
    }
}
