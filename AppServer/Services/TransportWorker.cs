/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using AppServer.Model;
using CoaApp.Core;
using CoaApp.Core.Errors;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using AppServer.Properties;

namespace AppServer.Services
{
    public class CoaActiveSession : ActiveSession
    {
        [NonSerialized]
        private readonly TcpClient _client;
        [NonSerialized]
        private readonly Thread _thread;
        private TransportState _state;
        [NonSerialized]
        private NetworkStream _networkStream;
        private DateTime _lastPacketTime = DateTime.Now;
        private string _clientType;
        private string _hostName;
        private string _ipAddress;
        private DateTime _loginTime;
        private CoaSession _session;
        private CoaUser _user;
        private string _version;
        private readonly CoaApplication _app;
        private string _transportLogPath;
        private byte[] _cryptKey;
        public string Version => _version;
        public string IpAddress => _ipAddress;

        public int SessionId { get; }
        public Guid ClietnUid { get; }
        internal byte[] CryptKey => _cryptKey;
        internal CoaActiveSession(CoaApplication app, object parent, TcpClient client, int id) : base(app, parent)
        {
            _app = app ?? throw new ArgumentNullException(nameof(app));
            _client = client;
            SessionId = id;
            _transportLogPath = null;//app.Settings.GetSettingValue<string>(AppSettings.ParamCollection.TransportLog);
            _thread = new Thread(ProcessTransportConnection)
            {
                Name = Resources.ThreadClientWorker
            };
            _thread.Start();
        }

        private void ProcessTransportConnection()
        {
            int requestCount = 0;
            _networkStream = _client.GetStream();
            _state = TransportState.Connecting;
            while (true)
            {
                try
                {
                    requestCount += 1;

                    if (_networkStream.CanRead)
                    {
                        var buffer = ReadMessage();
                        ExchangeMessage msg = null;
                        //Обрабатываем полученные данные, вызываем метод API и передаем ему параметры и прочее
                        try
                        {
                            msg = buffer.Deserialize();
                            WriteTransportDebugLog(msg, SessionId, requestCount);
#if DEBUG
                            var prm = (msg.Parameters)?.Aggregate(string.Empty, (current, parameter) => current + ((parameter ?? "null") + ","));
                            if (prm?.Length > 1)
                                prm = prm.Remove(prm.Length - 1);
                            WriteConsoleLineInDebug($"Клиент={SessionId}, запрос={requestCount}, метод={msg.Method}({prm})", false);
                            var sw = new Stopwatch();
                            sw.Start();
#endif
                            msg = ProcessRequest(msg);
#if DEBUG
                            sw.Stop();
                            if (sw.ElapsedMilliseconds < 500)
                                WriteConsoleLineInDebug($"Запрос выполнен за {sw.ElapsedMilliseconds} мс.", false);
                            else
                                WriteConsoleLineInDebug($"Запрос выполнен за {sw.ElapsedMilliseconds} мс.", true);

#endif
                            _lastPacketTime = DateTime.Now;
                        }
                        catch (Exception ex)
                        {
                            if (msg == null)//были проблемы с десиарелизацией сообщения
                                msg = new ExchangeMessage
                                {
                                    TimeSend = DateTime.Now,
                                    Error = new SerializationMessageException(ex),
                                    Method = "Close"
                                };
                            else
                                msg = new ExchangeMessage(msg) { TimeSend = DateTime.Now, Error = new SerializationMessageException(ex) };
                            Application.WriteLogMessage(ex.Message);
                            Application.WriteLogMessage(ex.StackTrace);
                            WriteConsoleLineInDebug(ex.Message, true);
                        }
                        WriteMessage(msg);

                        if (_state == TransportState.Closing)
                            return; //Terminate();
                    }
                    else
                    {
                        Application.WriteLogMessage($"Невозможно читать из потока, прерывание сесии для {UserName}, сессия {SessionId}");
                        return;//Terminate();
                    }
                }
                catch (ThreadAbortException)
                {
                    _client.Close();
                    Closed?.Invoke(this, null);
                }
                catch (SocketException ex)
                {
                    _client.Close();
                    Closed?.Invoke(this, null);
                    WriteConsoleLineInDebug(ex.ToString(), true);
                    return;//Terminate();
                }
                catch (Exception ex)
                {
                    _client.Close();
                    Closed?.Invoke(this, null);
                    WriteConsoleLineInDebug(ex.ToString(), true);
                    WriteConsoleLineInDebug(ex.StackTrace, true);
                    return; //Terminate();
                }
            }
        }

        public void Terminate()
        {
            _thread.Abort();
        }

        public void Close(object sender, bool terminate)
        {
            _state = TransportState.Closing;
            WriteMessage(new ExchangeMessage
            {
                Method = "Close",
                TimeSend = DateTime.Now
            });
            Closed?.Invoke(this, null);
        }
        public void Close()
        {
            _state = TransportState.Closing;
            var msg = new ExchangeMessage
            {
                Method = "Close",
                TimeSend = DateTime.Now
            };
            WriteMessage(msg);
            _client.Close();
        }

        protected override string OnGetClientType()
        {
            return base.OnGetClientType();
        }

        protected override string OnGetHostName()
        {
            return _hostName;
        }

        protected override string OnGetUserName()
        {
            return _user.DisplayName;
        }
        protected override DateTime OnGetIdleTime()
        {
            var span = (DateTime.Now - _lastPacketTime);
            return new DateTime(span.Ticks);
        }
        private ExchangeMessage ProcessRequest(ExchangeMessage msg)
        {
            switch (_state)
            {
                case TransportState.Connecting:
                    {
                        var rand = new Random();
                        _cryptKey = new byte[10];
                        rand.NextBytes(_cryptKey);
                        _state = TransportState.Authenticate;
                        return new ExchangeMessage(msg)
                        {
                            Data = _cryptKey,
                            TimeSend = DateTime.Now,
                        };
                    }
                case TransportState.Authenticate:
                    {
                        try
                        {
                            _session = _app.OpenSession(msg.Parameters[0].ToString(), msg.Parameters[1]?.ToString(), msg.Parameters[2]?.ToString()) as CoaSession;//new ServerSession(_app, this, _user, _cryptKey);
                            _user = _session.ActiveUser as CoaUser;
                            _state = TransportState.Work;
                            _loginTime = DateTime.Now;
                            _clientType = msg.Parameters[4]?.ToString();
                            _hostName = msg.Parameters[5]?.ToString();
                            _ipAddress = msg.Parameters[6].ToString();
                            _version = msg.Parameters[7]?.ToString();
                            Application.WriteLogMessage(
                                $"Пользователь {msg.Parameters[0]} авторизован, сессия [{SessionId}]");
                            _transportLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Transport", msg.Parameters[0].ToString().Replace('\\', '_'));
                            if (!Directory.Exists(_transportLogPath))
                                Directory.CreateDirectory(_transportLogPath);
                        }
                        catch (Exception ex)
                        {
                            Application.WriteLogMessage(ex.Message);
                            Application.WriteLogMessage(ex.StackTrace);
                            _state = TransportState.Closing;
                            return new ExchangeMessage(msg)
                            {
                                Error = new AuthenticationException(),
                                TimeSend = DateTime.Now,
                            };
                        }
                        return new ExchangeMessage(msg)
                        {
                            Data = SessionId,
                            TimeSend = DateTime.Now,
                            Method = msg.Method
                        };
                    }
                case TransportState.Work:
                    try
                    {
                        //TODO: execute user call here
                        return new ExchangeMessage(msg)
                        {                            
                            Data = null,//TODO: fix this
                            TimeSend = DateTime.Now,
                        };
                    }
                    catch (Exception ex)
                    {
                        if (ex.InnerException != null)
                            throw ex.InnerException;
                        throw;
                    }
            }
            return new ExchangeMessage { Method = "Close" };
        }

        public void NotifyClient(ApiMessage c)
        {
            var msg = new ExchangeMessage
            {
                TimeSend = DateTime.Now,
                Data = c,
                Method = "NotifyServer"
            };
            var buffer = msg.Serialize();
            var sendData = new byte[buffer.Length + 4];
            BitConverter.GetBytes(buffer.Length).CopyTo(sendData, 0);
            buffer.CopyTo(sendData, 4);
            _networkStream.Write(sendData, 0, sendData.Length);
            _networkStream.Flush();
        }
        private void NotifyClients(object sender, ApiMessage c)
        {
            Notify?.Invoke(this, c);
        }

        private byte[] ReadMessage()
        {
            var dataSize = 1024;
            var buffer = new byte[dataSize];
            var size = 0;
            var sizeInitiated = false;
            var position = 0;
            do
            {
                var tmpStream = new byte[dataSize];
                var reads = _networkStream.Read(tmpStream, 0, tmpStream.Length);
                //Определим размер получаемых данных
                if (!sizeInitiated)
                {
                    var sizeByte = tmpStream.Take(4).ToArray();//int32
                    size = BitConverter.ToInt32(sizeByte, 0);
                    tmpStream = tmpStream.Skip(4).ToArray();
                    reads -= 4;
                    sizeInitiated = true;
                }

                if (reads <= dataSize)
                {
                    Array.Resize(ref buffer, reads + position);
                    tmpStream.Take(reads).ToArray().CopyTo(buffer, position);
                    //Console.WriteLine(reads);
                    position += reads;
                }
                else
                {
                    buffer = tmpStream;
                }
            } while (buffer.Length < size);
            _lastPacketTime = DateTime.Now;
            return buffer;
        }
        /// <summary>
        /// Отправка ответа клиенту.
        /// Ответ не отправляется, если был вызван метод CloseSession
        /// </summary>
        /// <param name="msg"></param>
        private void WriteMessage(ExchangeMessage msg)
        {
            if (msg.Method == "CloseSession")
            {
                WriteConsoleLineInDebug($"\t\tОтвет клиенту не отправляется {SessionId}|{UserName}, метод={msg.Method}", false);
                return;
            }
            var buffer = msg.Serialize();
            WriteConsoleLineInDebug($"\t\tОтвет клиенту {SessionId}|{UserName}, метод={msg.Method} длиной {buffer.Length}", false);
            //Пишем размер данных впереди данных
            var sendData = new byte[buffer.Length + 4];
            BitConverter.GetBytes(buffer.Length).CopyTo(sendData, 0);
            buffer.CopyTo(sendData, 4);
            _networkStream.Write(sendData, 0, sendData.Length);//Передаем сами данные
            _networkStream.Flush();
            WriteTransportLogMessage($"\t\tОтвет клиенту {SessionId}|{UserName}, метод={msg.Method} длиной {buffer.Length}\n");
        }

        private void WriteTransportDebugLog(ExchangeMessage msg, int sessionId, int requestCount)
        {
            var prm = (msg.Parameters)?.Aggregate(string.Empty, (current, parameter) => current + ((parameter ?? "null") + ","));
            if (prm?.Length > 1)
                prm = prm.Remove(prm.Length - 1);
            WriteTransportLogMessage($"Клиент={sessionId}, запрос={requestCount}, метод={msg.Method}({prm})");
        }
        private void WriteTransportLogMessage(string msg)
        {
            if (false)//_app.Settings.GetSettingValue<bool>(AppSettings.ParamCollection.WriteTransportLog))
            {
                var currdate = DateTime.Now.Date;
                var path = Path.Combine(_transportLogPath, $"{currdate.Year}_{currdate.Month}_{currdate.Day}.log");
                File.AppendAllText(path, $"[{DateTime.Now}] " + msg + Environment.NewLine);
            }
        }
        public static void WriteConsoleLineInDebug(string msg, bool isError)
        {
#if DEBUG
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            if (isError)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
#endif            
        }
        public event EventHandler Closed;
        public event EventHandler<ApiMessage> Notify;        
    }

    internal enum TransportState
    {
        Connecting,
        Authenticate,
        Work,
        Closing
    }
}
