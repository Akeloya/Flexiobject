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
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    public abstract class ActiveSession : AppBase, IActiveSession
    {
        private readonly DateTime _loginTime;
        public string ClientType => OnGetClientType();

        public string HostName => OnGetHostName();

        public DateTime LoginTime => _loginTime;

        public DateTime IdleTime => OnGetIdleTime();

        public string UserName => OnGetUserName();

        protected ActiveSession(Application app, object parent) : base(app, parent)
        {
            _loginTime = DateTime.Now;
        }
        public void Close()
        {
            throw new NotImplementedException();
        }

        protected virtual string OnGetClientType()
        {
            return "api";
        }

        protected virtual string OnGetHostName()
        {
            return "localhost";
        }

        protected virtual string OnGetUserName()
        {
            return string.Empty;
        }

        protected virtual DateTime OnGetIdleTime()
        {
            var span = DateTime.Now - _loginTime;
            return new DateTime(span.Ticks);
        }
    }
}
