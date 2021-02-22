/*
 *  "Custom object application core"
 *  An application that implements the ability to customize object templates and actions on them.
 *  Copyright (C) 2019 by Maxim V. Yugov.
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
using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Environment definition of application
    /// </summary>
    public abstract class CoaInvironment
    {
        private static string _serverVersion;
        private static string _clientVersion;
        private static Application _application;
        [ThreadStatic] private static Session _session;
        internal static string ServerVersion => _serverVersion;
        internal static string ClientVersion => _clientVersion;
        internal static Application Application => _application;
        internal static Session ActiveSession => _session;
        /// <summary>
        /// Definition of base constructor
        /// </summary>
        protected CoaInvironment(string serverVersion, string clientVersion, Application app)
        {
            _serverVersion = serverVersion;
            _clientVersion = clientVersion;
            _application = app;
        }
        /// <summary>
        /// Update session info
        /// </summary>
        /// <param name="session">ThreadStatic session data</param>
        protected virtual void SetSession(Session session)
        {
            _session = session;
        }
    }
}