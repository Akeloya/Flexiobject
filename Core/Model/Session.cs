/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
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

namespace CoaApp.Core
{
    public abstract class CoaSession : AppBase, ISession
    {
        protected CoaSession(CoaApplication app): base(app, app)
        {

        }
        public abstract ICustomFolders RequestFolders { get; }
        public abstract IActiveSessions ActiveSessions { get; }
        public abstract string Username { get; }
        public abstract IPictures Pictures { get; }
        public abstract IUser ActiveUser { get; }
        public abstract IGroups Groups { get; }
        public abstract IUsers Users { get; }
        public abstract IScheduledTasks ScheduledTasks { get; }
        public abstract IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters);        
        public abstract ICustomObjects GetDeletedRequests();
        public abstract IGroup GetGroupByUniqueId(int id);        
        public abstract ICustomObject GetRequestByUniqueId(long id);        
        public abstract ICustomFolder GetRequestFolderByPath(string path);        
        public abstract ICustomFolder GetRequestFolderByUniqueId(int id);        
        public abstract IScript GetServerScript(string name);
        public abstract IState GetStateByUniqueId(int id);        
        public abstract string GetSystemParameter(string table, string name);        
        public abstract IUser GetUserByUniqueId(int id);        
        public abstract IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id);        
        public abstract IView GetViewByUniqueId(int id);
        public void LogMessage(string msg)
        {
            Application.WriteLogMessage(msg);
        }
        public abstract void Logoff();
        public abstract void NotifyUser(object reciever, string message, ICustomObject linkedRequest);
    }
}
