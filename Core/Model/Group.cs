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
using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core
{
    public abstract class CoaGroup : AppBase, IGroup
    {
        private bool _isBaseGroup;
        private ICustomObject _userObject;
        private string _displayName;
        private string _emailAddress;
        private CoaGroupBehaviorTypes _emailBehavior;
        private long _objectId;
        private int _uniqueId;
        protected CoaGroup(IApplication app, object parent, bool isBase = false) : base(app, parent)
        {
            _isBaseGroup = isBase;
        }

        protected CoaGroup(IApplication app, object parent, int uniqueId, bool isBase = false, long customObjId = 0) : base(app, parent)
        {
            _uniqueId = uniqueId;
            _objectId = customObjId;
            _isBaseGroup = isBase;
        }
        public static bool operator ==(CoaGroup left, IGroup right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public static bool operator !=(CoaGroup left, IGroup right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public int UniqueId => _uniqueId;
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupName, true)]
        public string Name {
            get
            {
                if (_isBaseGroup)
                    return Resource.BaseGroupDisplayName;
                return _displayName ?? string.Format(Resource.GroupName, _uniqueId);
            }
        }

        public string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupEmailAddress, false)]
        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupEmailBehavior, true)]
        public CoaGroupBehaviorTypes EmailBehavior
        {
            get { return _emailBehavior; }
            set
            {
                _emailBehavior = value;
                if (Object != null)
                {
                    if (!_userObject.CustomObjFolder[CoaApplicationFolders.UserGroups])
                        throw new GroupSyncRequestException();
                    var field = _userObject.CustomObjFolder[CoaApplicationFolders.UserGroups, CoaApplicationFoldersProperties.GroupEmailAddress];
                    if (field != null)
                        _userObject.UserFields[field.Alias].TValue = value.ToString();
                }
            }
        }
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupContainedGroups, false)]
        public abstract IGroups Groups { get; }

        public abstract IGroups GroupsRecursive { get; }
        public ICustomObject Object
        {
            get
            {
                if (_objectId > 0 && _userObject == null)
                    _userObject = OnGetObject(_objectId);
                return _userObject;
            }
            set
            {
                if(value == null)
                {
                    if (Object != null && Object.CustomObjFolder[CoaApplicationFolders.UserGroups])
                        throw new NotImplementedException();
                }

                if (!value.CustomObjFolder[CoaApplicationFolders.UserGroups])
                    throw new GroupFolderSyncException();
                _userObject = value;
            }
        }
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupContainedUsers, true)]
        public abstract IUsers Users { get; }
        public abstract IUsers UsersRecurcive { get; }
        public void Save()
        {
            if (_isBaseGroup)
                throw new CoaGroupModificationException();
            _uniqueId = OnSave();
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as IGroup);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public bool Equals(IGroup other)
        {
            if (other == null)
                return false;
            return UniqueId == other.UniqueId;
        }
        public void Delete()
        {
            if (_isBaseGroup)
                throw new CoaGroupModificationException();
            OnDelete();
        }
        public abstract void AddGroup(IGroup group);
        public abstract void AddUser(IUser user);
        public abstract bool IsInGroup(string groupName);
        public abstract bool IsInGroupRecursive(string groupName);
        public abstract void RemoveGroup(IGroup group);
        public abstract void RemoveUser(IUser user);
        public abstract void SendEmail();
        protected abstract int OnSave();
        protected abstract ICustomObject OnGetObject(long objectId);
        protected abstract void OnDelete();
    }
}
