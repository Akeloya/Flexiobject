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
using CoaApp.Core;
using DbProvider;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppServer.Model
{
    public class CoaApplication: Application
    {
        public CoaApplication() : base()
        {
            
        }

        public Session OpenSession(string login, string domain, string password)
        {
            return new CoaSession(this);
        }
        protected override void OnLogMessage(string message)
        {
            base.OnLogMessage(message);
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
            throw new NotImplementedException();
        }

        internal void Initiate()
        {
            throw new NotImplementedException();
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }
    }
}
