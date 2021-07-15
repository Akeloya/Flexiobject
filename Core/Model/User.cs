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
    ///<inheritdoc/>
    public abstract class CoaUser : AppBase, IUser
    {
        private int _uniqueId;
        private CoaUserAuthTypes _authType;
        private readonly long _custObjId;
        private ICustomObject _custObject;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="custObjId"></param>
        protected CoaUser(IApplication app, object parent, long custObjId = 0) : base(app, parent)
        {
            _custObjId = custObjId;
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/equality/*'/>
        public static bool operator ==(CoaUser left, IUser right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/inequality/*'/>
        public static bool operator !=(CoaUser left, IUser right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserActive, true)]
        public bool Active { get; set; }
        ///<inheritdoc/>
        public ICustomFolder DefaultCustomFolder { get; set; }                
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserDisplayName, true)]
        public string DisplayName { get; set; }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserWindowsDomainName, true)]
        public string DomainName { get; set; }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserEmailAddress, false)]
        public string EmailAddress { get; set; }
        ///<inheritdoc/>
        public bool HasDefaultCustomFolder { get; set; }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserLoginName, false)]
        public string LoginName { get; set; }
        ///<inheritdoc/>
        public string Name => DisplayName;
        ///<inheritdoc/>
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
        ///<inheritdoc/>
        public string OutgoingEmailAccount { get; set; }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserPassword, false)]
        public string Password { get; set; }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserSuperuser, false)]
        public bool SuperUser { get; set; }
        ///<inheritdoc/>
        public int UniqueId => _uniqueId;
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.UserAuthentication, false)]
        public CoaUserAuthTypes AuthenticationType { get { return _authType; } set { _authType = value; } }
        ///<inheritdoc/>
        public bool Equals(IUser other)
        {
            if (other == null)
                return false;
            return UniqueId == other.UniqueId;
        }
        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as IUser);
        }
        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        ///<inheritdoc/>
        public void Save()
        {
            switch (_authType)
            {
                case CoaUserAuthTypes.Internal:
                    if (string.IsNullOrEmpty(Password))
                        throw new CoaUserPasswordRequiredException();
                    if (string.IsNullOrEmpty(LoginName))
                        throw new CoaUserLoginRequiredException();
                    break;
                case CoaUserAuthTypes.Windows:
                    if (string.IsNullOrEmpty(LoginName))
                        throw new CoaUserLoginRequiredException();
                    break;
                case CoaUserAuthTypes.NoAuth:
                    Password = null;
                    break;
            }

            _uniqueId = OnSave();
        }
        ///<inheritdoc/>
        public abstract IGroups Groups { get; }
        ///<inheritdoc/>
        public abstract IGroups GroupsRecursive { get; }
        ///<inheritdoc/>
        public abstract void AddToGroup(IGroup group);
        ///<inheritdoc/>
        public abstract void Delete();
        ///<inheritdoc/>
        public abstract bool IsInGroup(string groupName);
        ///<inheritdoc/>
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
