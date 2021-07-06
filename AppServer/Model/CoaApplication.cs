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
using AppServer.Properties;
using AppServer.Services;
using CoaApp.Core;
using DbProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace AppServer.Model
{
    public class CoaApplication: Application
    {
        [NonSerialized] TcpListener _listener;
        [NonSerialized] ILogger _logger;
        private readonly AppConfig _config;
        private bool _initiated;
        public readonly List<CoaActiveSession> Clients = new List<CoaActiveSession>();
        
        public CoaApplication(IConfiguration config, ILogger logger) : base()
        {
            _logger = logger;
            var appConfig = new AppConfig();
            config.GetSection(AppConfig.ConfigName).Bind(appConfig);
            _config = appConfig;

            SqlManager.RegisterManager(_config.Database);

            _listener = new TcpListener(IPAddress.Any,_config.Port);

            FileVersionInfo versionInfo = VersionInfo();           
            WriteLogMessage(Resources.ServerStrInitializing);
            WriteLogMessage($"{versionInfo}");
            WriteLogMessage(string.Format(Resources.ServerStrDbConnection,
                _config.Database.Server,
                _config.Database.DbName,
                _config.Database.UserName ?? _config.Database.Security));
        }

        public Session OpenSession(string login, string domain, string password)
        {
            return new CoaSession(this);
        }
        public static FileVersionInfo VersionInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return FileVersionInfo.GetVersionInfo(assembly.Location);
        }
        protected override void OnLogMessage(string message)
        {
            _logger.Log(LogLevel.Information, message);
        }

        protected override Session OnOpenSession(string host, int port)
        {
            return new CoaSession(this);
        }

        protected override Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            return new CoaSession(this);
        }

        internal void ShutdownServer()
        {
            _listener.Stop();
            
        }

        internal void Initiate()
        {
            if (_initiated)
                return;
            WriteLogMessage(Resources.ServerStrStarting);


            _initiated = true;
        }

        internal void Start()
        {
            _listener.Start();

            int counter = 0;
            bool continiouseWait = true;
            while (continiouseWait)
            {
                counter += 1;
                TcpClient clientSocket = _listener.AcceptTcpClient();

#if DEBUG
                _logger.LogInformation(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
#endif
                CoaActiveSession client = new CoaActiveSession(this, this, clientSocket, counter);
                client.Closed += Client_Closed;
                client.Notify += NotifyClietns;
                Clients.Add(client);
            }
        }

        private void Client_Closed(object sender, EventArgs e)
        {
            CoaActiveSession client = (CoaActiveSession)sender;
            Clients.Remove(client);
        }

        private void NotifyClietns(object sender, ApiMessage c)
        {
            foreach (CoaActiveSession client in Clients)
            {
                if (c.SessionId == client.SessionId)
                    continue;

                client.NotifyClient(c);
            }
        }
    }
}
