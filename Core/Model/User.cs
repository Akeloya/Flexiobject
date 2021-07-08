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

using CoaApp.Core.Enumes;
using CoaApp.Core.Exceptions;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    public abstract class CoaUser : AppBase, IUser
    {
        private int _uniqueId;
        private CoaUserAuthenticationTypes _authType;
        private long _custObjId;
        private ICustomObject _custObject;
        protected CoaUser(IApplication app, object parent, long custObjId = 0) : base(app, parent)
        {
            _custObjId = custObjId;
        }
        public static bool operator ==(CoaUser left, IUser right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public static bool operator !=(CoaUser left, IUser right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserActive, true)]
        public bool Active { get; set; }
        public ICustomFolder DefaultCustomFolder { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserDepartment, false)]
        public string Department { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserDisplayName, true)]
        public string DisplayName { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserWindowsDomainName, true)]
        public string DomainName { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserEmailAddress, false)]
        public string EmailAddress { get; set; }        
        public bool HasDefaultCustomFolder { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserLoginName, false)]
        public string LoginName { get; set; }
        public string Name => DisplayName;
        public ICustomObject Object
        {
            get
            {
                if (_custObjId > 0 && _custObject == null)
                    _custObject = OnGetObject();
                return _custObject;
            }
            set
            {
                if (value == null && Object != null)
                    throw new NotImplementedException();
                if(value != null)
                {
                    if (!value.CustomObjFolder[CoaApplicationFolders.UserAccounts])
                        throw new UserSyncRequestException();
                }
                _custObject = value;
            }
        }
        public string OutgoingEmailAccount { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserPassword, false)]
        public string Password { get; set; }
        [AppFolderProperty(CoaApplicationFoldersProperties.UserSuperuser, false)]
        public bool SuperUser { get; set; }
        public int UniqueId => _uniqueId;
        [AppFolderProperty(CoaApplicationFoldersProperties.UserAuthentication, false)]
        public CoaUserAuthenticationTypes AuthenticationType { get { return _authType; } set { _authType = value; } }
        public bool Equals(IUser other)
        {
            if (other == null)
                return false;
            return UniqueId == other.UniqueId;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as IUser);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public void Save()
        {
            switch (_authType)
            {
                case CoaUserAuthenticationTypes.Internal:
                    if (string.IsNullOrEmpty(Password))
                        throw new CoaUserPasswordRequiredException();
                    if (string.IsNullOrEmpty(LoginName))
                        throw new CoaUserLoginRequiredException();
                    break;
                case CoaUserAuthenticationTypes.Windows:
                    if (string.IsNullOrEmpty(LoginName))
                        throw new CoaUserLoginRequiredException();
                    break;
                case CoaUserAuthenticationTypes.NoAuth:
                    Password = null;
                    break;
            }

            _uniqueId = OnSave();
        }
        public abstract IGroups Groups { get; }
        public abstract IGroups GroupsRecursive { get; }
        public abstract void AddToGroup(IGroup group);
        public abstract void Delete();
        public abstract bool IsInGroup(string groupName);
        public abstract bool IsInGroupRecursive(string groupName);
        /// <summary>
        /// Save object implementation
        /// </summary>
        /// <returns></returns>
        protected abstract int OnSave();
        /// <summary>
        /// Getting linked custom object
        /// </summary>
        /// <returns></returns>
        protected abstract ICustomObject OnGetObject();
    }
}
