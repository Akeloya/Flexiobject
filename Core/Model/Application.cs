﻿/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FlexiObject.Core
{
    /// <summary>
    /// Application instance
    /// </summary>
    public abstract class Application : MarshalByRefObject, IApplication
    {
        /// <summary>
        /// Internal application folders
        /// </summary>
        /// <returns></returns>
        public static List<CoaApplicationFolders> GetApplicationFolders()
        {
            List<CoaApplicationFolders> result = new()
            {
                CoaApplicationFolders.UserAccounts,
                CoaApplicationFolders.UserGroups
            };
            return result;
        }
        /// <summary>
        /// Folder fields for internal app folders
        /// </summary>
        /// <param name="type">Internal folder type</param>
        /// <returns></returns>
        public static Dictionary<CoaApplicationFoldersProperties, bool> GetAllowedFieldsByAppFolderType(CoaApplicationFolders type)
        {
            Dictionary<CoaApplicationFoldersProperties, bool> result = new();
            switch (type)
            {
                case CoaApplicationFolders.UserAccounts:
                    result = new Dictionary<CoaApplicationFoldersProperties, bool>{
                        { CoaApplicationFoldersProperties.UserActive, true},
                        { CoaApplicationFoldersProperties.UserAuthentication, true},
                        { CoaApplicationFoldersProperties.UserCalendar, false},
                        { CoaApplicationFoldersProperties.UserDepartment, false},
                        { CoaApplicationFoldersProperties.UserDescription, false},
                        { CoaApplicationFoldersProperties.UserDisplayName, true},
                        { CoaApplicationFoldersProperties.UserEmailAddress, false},
                        { CoaApplicationFoldersProperties.UserLastLogin, false},
                        { CoaApplicationFoldersProperties.UserLocked, true},
                        { CoaApplicationFoldersProperties.UserLoginName, false},
                        { CoaApplicationFoldersProperties.UserPassword, true},
                        { CoaApplicationFoldersProperties.UserPhone, false},
                        { CoaApplicationFoldersProperties.UserSuperuser, false},
                        { CoaApplicationFoldersProperties.UserWindowsDomainName, false } };
                    break;
                case CoaApplicationFolders.UserGroups:
                    result = new Dictionary<CoaApplicationFoldersProperties, bool> {
                        { CoaApplicationFoldersProperties.GroupContainedGroups, false },
                        { CoaApplicationFoldersProperties.GroupContainedUsers, false },
                        { CoaApplicationFoldersProperties.GroupEmailAddress, false },
                        { CoaApplicationFoldersProperties.GroupEmailBehavior, false },
                        { CoaApplicationFoldersProperties.GroupName, true } };
                    break;
            }
            return result;
        }

        [ThreadStatic]private static Session _activeSession;
        [JsonIgnore]//TODO: check after implement
        public Session ActiveSession => _activeSession;
        public ISession OpenSession(string hostName, int port, string userName = null, string password = null)
        {
            if (string.IsNullOrEmpty(hostName))
                throw new ArgumentNullException(nameof(hostName));
            if (port == 0)
                throw new ArgumentNullException(nameof(port));
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
                _activeSession = OnOpenSession(hostName, port);
            else
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException(nameof(userName));
                if(string.IsNullOrEmpty(password))
                    throw new ArgumentNullException(nameof(password));
                _activeSession = OnOpenSessionWithLoginPassword(hostName, port, userName, password);
            }
            return _activeSession;
        }
        /// <summary>
        /// Loggin message to server log
        /// </summary>
        /// <param name="msg">Message string</param>
        public abstract void WriteLogMessage(string msg);

        /// <summary>
        /// Realization of opening session method by using NTML auth
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="port">Port number</param>
        /// <returns></returns>
        protected abstract Session OnOpenSession(string host, int port);

        /// <summary>
        /// Realization of opening session method by using internal auth
        /// </summary>
        /// <param name="host">Network host name</param>
        /// <param name="port">Port number</param>
        /// <param name="login">User login name</param>
        /// <param name="password">User password string</param>
        /// <returns></returns>
        protected abstract Session OnOpenSessionWithLoginPassword(string host, int port, string login, string password);
    }
}
