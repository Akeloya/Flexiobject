using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace CoaApp.Core
{
    /// <summary>
    /// Application instance
    /// </summary>
    public abstract class CoaApplication : MarshalByRefObject, IApplication
    {
        [ThreadStatic] private static ISession _activeSession;
        ///<inheritdoc/>
        public ISession ActiveSession => _activeSession;
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
        public static Dictionary<CoaApplicationFoldersProperties, bool> GetAllowedFielsByAppFolderType(CoaApplicationFolders type)
        {
            Dictionary<CoaApplicationFoldersProperties, bool> result = new();
            switch (type)
            {
                case CoaApplicationFolders.UserAccounts:
                    result = new Dictionary<CoaApplicationFoldersProperties, bool>{
                        { CoaApplicationFoldersProperties.UserActive, true},
                        { CoaApplicationFoldersProperties.UserAuthentication, true},
                        { CoaApplicationFoldersProperties.UserDescription, false},
                        { CoaApplicationFoldersProperties.UserDisplayName, true},
                        { CoaApplicationFoldersProperties.UserEmailAddress, false},
                        { CoaApplicationFoldersProperties.UserLastLogin, false},
                        { CoaApplicationFoldersProperties.UserLocked, true},
                        { CoaApplicationFoldersProperties.UserLoginName, false},
                        { CoaApplicationFoldersProperties.UserPassword, true},
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
        ///<inheritdoc/>
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
        ///<inheritdoc/>
        public void WriteLogMessage(string msg)
        {
            if (string.IsNullOrEmpty(msg))
                return;
            var rows = msg.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var logMsg = string.Empty;
            var now = DateTime.Now.ToShortDateString();
            foreach (string row in rows)
                logMsg += string.Format("[{0}] {1}\n", now, row);
            OnLogMessage(logMsg);
        }

        /// <summary>
        /// Realization of opening session method by using NTML auth
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="port">Port number</param>
        /// <returns></returns>
        protected abstract ISession OnOpenSession(string host, int port);

        /// <summary>
        /// Realization of opening session method by using internal auth
        /// </summary>
        /// <param name="host">Network host name</param>
        /// <param name="port">Port number</param>
        /// <param name="login">User login name</param>
        /// <param name="password">User password string</param>
        /// <returns></returns>
        protected abstract ISession OnOpenSessionWithLoginPassword(string host, int port, string login, string password);
        /// <summary>
        /// Realization of logging message
        /// </summary>
        /// <param name="message"></param>
        protected abstract void OnLogMessage(string message);        
    }
}
