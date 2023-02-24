using FlexiObject.Core.Config;
using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository;

using System;
using System.Collections.Generic;

namespace FlexiObject.API.Model
{
    /// <summary>
    /// Application instance
    /// </summary>
    [Serializable]
    public class Application : MarshalByRefObject, IApplication
    {
        private readonly IContainer _container;
        public Application(IContainer container)
        {
            _container = container;
        }
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

        [ThreadStatic]private static ISession _activeSession;
        public ISession ActiveSession => _activeSession;
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
        public void WriteLogMessage(string msg)
        {
            _container.Get<ILogRepository>().LogMessage(msg);
        }

        /// <summary>
        /// Realization of opening session method by using NTML auth
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="port">Port number</param>
        /// <returns></returns>
        protected ISession OnOpenSession(string host, int port)
        {
            return _container.Get<ISessionRepository>().CreateSession(host, port);
        }

        /// <summary>
        /// Realization of opening session method by using internal auth
        /// </summary>
        /// <param name="host">Network host name</param>
        /// <param name="port">Port number</param>
        /// <param name="login">User login name</param>
        /// <param name="password">User password string</param>
        /// <returns></returns>
        protected ISession OnOpenSessionWithLoginPassword(string host, int port, string login, string password)
        {
            return _container.Get<ISessionRepository>().CreateSession(host, port, login, password);
        }
    }
}
