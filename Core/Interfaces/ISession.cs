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
namespace CoaApp.Core.Interfaces
{
    public interface ISession : IBase
    {
        /// <summary>
        /// All folders
        /// </summary>
        ICustomFolders RequestFolders { get; }
        /// <summary>
        /// Application users active sessions
        /// </summary>
        IActiveSessions ActiveSessions { get; }
        /// <summary>
        /// Current user
        /// </summary>
        string Username { get; }
        /// <summary>
        /// Picture collection in server
        /// </summary>
        IPictures Pictures { get; }
        /// <summary>
        /// Active user
        /// </summary>
        IUser ActiveUser { get; }
        /// <summary>
        /// Application groups
        /// </summary>
        IGroups Groups { get; }
        /// <summary>
        /// Application users. By default will be returned only active users.
        /// If current user has 'superuser' flag, will be returned all users include inactive.
        /// </summary>
        IUsers Users { get; }
        /// <summary>
        /// Close this session
        /// </summary>
        void Logoff();
        /// <summary>
        /// Object moved to trash bin
        /// </summary>
        /// <returns>ICustomObjects collection with only objects in trash bin</returns>
        ICustomObjects GetDeletedRequests();
        /// <summary>
        /// Get user object by uniqueId
        /// </summary>
        /// <param name="id">Object unique identifier</param>
        /// <returns>null/ICustomObject</returns>
        ICustomObject GetRequestByUniqueId(long id);
        /// <summary>
        /// Scheduled tasks on server
        /// </summary>
        IScheduledTasks ScheduledTasks { get; }
        /// <summary>
        /// Get folder by path
        /// </summary>
        /// <param name="path">Folder[\Nested folder[\...]</param>
        /// <returns></returns>
        ICustomFolder GetRequestFolderByPath(string path);
        /// <summary>
        /// Get folder by id
        /// </summary>
        /// <param name="id">Folder Id</param>
        /// <returns>null/ICustomFolder</returns>
        ICustomFolder GetRequestFolderByUniqueId(int id);
        /// <summary>
        /// Log message to application log
        /// </summary>
        /// <param name="msg">Message to log</param>
        void LogMessage(string msg);
        /// <summary>
        /// Get system parameter
        /// </summary>
        /// <param name="table">Registry key</param>
        /// <param name="name">Parameter name</param>
        /// <returns>String value of parameter</returns>
        string GetSystemParameter(string registry, string name);
        /// <summary>
        /// Get application user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>null/IUser</returns>
        IUser GetUserByUniqueId(int id);
        /// <summary>
        /// Get group by id
        /// </summary>
        /// <param name="id">Group id</param>
        /// <returns>Application group. <see cref="IGroup"/></returns>
        IGroup GetGroupByUniqueId(int id);
        /// <summary>
        /// Get server scenario (script) by name
        /// </summary>
        /// <param name="name">Script name</param>
        /// <returns>IScript/null</returns>
        IScript GetServerScript(string name);
        /// <summary>
        /// Get workflow state by id
        /// </summary>
        /// <param name="id">State id</param>
        /// <returns>IState/null</returns>
        IState GetStateByUniqueId(int id);
        /// <summary>
        /// Notify user
        /// </summary>
        /// <param name="reciever">Reciever: object IUser or ICustomObject (linked with IUser)</param>
        /// <param name="message">Message</param>
        /// <param name="linkedRequest">Link to ICustomObject if nessesary</param>
        void NotifyUser(object reciever, string message, ICustomObject linkedRequest);
        /// <summary>
        /// Get user field definition by id
        /// </summary>
        /// <param name="id">User field identifier</param>
        /// <returns>IUserFieldDefinition/null</returns>
        IUserFieldDefinition GetUserFieldDefinitionByUniqueId(int id);
        /// <summary>
        /// User requerst to stored data
        /// </summary>
        /// <param name="sqlCommand">Sql string</param>
        /// <param name="parameters">Request parameters</param>
        /// <returns></returns>
        IQueryResult ExecuteSqlRequest(string sqlCommand, params object[] parameters);
        /// <summary>
        /// Get folder view by id
        /// </summary>
        /// <param name="id">View id</param>
        /// <returns></returns>
        IView GetViewByUniqueId(int id);
    }
}
