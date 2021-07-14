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
    ///<inheritdoc/>
    public abstract class CoaSession : AppBase, ISession
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        protected CoaSession(CoaApplication app): base(app, app)
        {

        }
        ///<inheritdoc/>
        public abstract ICustomFolders RequestFolders { get; }
        ///<inheritdoc/>
        public abstract IActiveSessions ActiveSessions { get; }
        ///<inheritdoc/>
        public abstract string Username { get; }
        ///<inheritdoc/>
        public abstract IPictures Pictures { get; }
        ///<inheritdoc/>
        public abstract IUser ActiveUser { get; }
        ///<inheritdoc/>
        public abstract IGroups Groups { get; }
        ///<inheritdoc/>
        public abstract IUsers Users { get; }
        ///<inheritdoc/>
        public abstract IScheduledTasks ScheduledTasks { get; }
        ///<inheritdoc/>
        public abstract IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters);
        ///<inheritdoc/>
        public abstract ICustomObjects GetDeletedRequests();
        ///<inheritdoc/>
        public abstract IGroup GetGroupByUniqueId(int id);
        ///<inheritdoc/>
        public abstract ICustomObject GetRequestByUniqueId(long id);
        ///<inheritdoc/>
        public abstract ICustomFolder GetRequestFolderByPath(string path);
        ///<inheritdoc/>
        public abstract ICustomFolder GetRequestFolderByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IScript GetServerScript(string name);
        ///<inheritdoc/>
        public abstract IState GetStateByUniqueId(int id);
        ///<inheritdoc/>
        public abstract string GetSystemParameter(string table, string name);
        ///<inheritdoc/>
        public abstract IUser GetUserByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id);
        ///<inheritdoc/>
        public abstract IView GetViewByUniqueId(int id);
        ///<inheritdoc/>
        public void LogMessage(string msg)
        {
            Application.WriteLogMessage(msg);
        }
        ///<inheritdoc/>
        public abstract void Logoff();
        ///<inheritdoc/>
        public abstract void NotifyUser(object reciever, string message, ICustomObject linkedRequest);
    }
}
