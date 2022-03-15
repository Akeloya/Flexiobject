﻿/*
 *  "Flexiobject core"
 *  An application that implements the ability to customize object templates and actions on them.
 *  Copyright (C) 2019 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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
using Flexiobject.Core.Interfaces;
using System;

namespace Flexiobject.Core
{
    public abstract class Session : AppBase<Application>, ISession
    {
        protected Session(Application app): base(app, app)
        {

        }
        public ICustomFolders RequestFolders => throw new NotImplementedException();

        public IActiveSessions ActiveSessions => throw new NotImplementedException();

        public string Username => throw new NotImplementedException();

        public IPictures Pictures => throw new NotImplementedException();

        public IUser ActiveUser => throw new NotImplementedException();

        public IGroups Groups => throw new NotImplementedException();

        public IUsers Users => throw new NotImplementedException();

        public IScheduledTasks ScheduledTasks => throw new NotImplementedException();

        public IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public ICustomObjects GetDeletedRequests()
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroupByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public ICustomObject GetRequestByUniqueId(long id)
        {
            throw new NotImplementedException();
        }

        public ICustomFolder GetRequestFolderByPath(string path)
        {
            throw new NotImplementedException();
        }

        public ICustomFolder GetRequestFolderByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IScript GetServerScript(string name)
        {
            throw new NotImplementedException();
        }

        public IState GetStateByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public string GetSystemParameter(string table, string name)
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public IView GetViewByUniqueId(int id)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string msg)
        {
            throw new NotImplementedException();
        }

        public void Logoff()
        {
            throw new NotImplementedException();
        }

        public void NotifyUser(object reciever, string message, ICustomObject linkedRequest)
        {
            throw new NotImplementedException();
        }
    }
}
