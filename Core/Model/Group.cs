using CoaApp.Core.Enumes;
using CoaApp.Core.Exceptions;
using CoaApp.Core.Interfaces;
using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaGroup : AppBase, IGroup
    {
        private readonly bool _isBaseGroup;
        private ICustomObject _userObject;
        private string _displayName;
        private string _emailAddress;
        private CoaGroupBehaviorTypes _emailBehavior;
        private readonly long _objectId;
        private int _uniqueId;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="isBase">Flag indicate is folder base for other folders</param>
        protected CoaGroup(IApplication app, object parent, bool isBase = false) : base(app, parent)
        {
            _isBaseGroup = isBase;
        }
        /// <summary>
        /// Constructor for existing groups
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="uniqueId">Group database Id</param>
        /// <param name="isBase">Base group flag</param>
        /// <param name="customObjId">Linked user object unique id</param>
        protected CoaGroup(IApplication app, object parent, int uniqueId, bool isBase = false, long customObjId = 0) : base(app, parent)
        {
            _uniqueId = uniqueId;
            _objectId = customObjId;
            _isBaseGroup = isBase;
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/equality/*'/>
        public static bool operator ==(CoaGroup left, IGroup right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        /// <include file='commonDocs.xml' path='docs/members[@name="comparisons"]/inequality/*'/>
        public static bool operator !=(CoaGroup left, IGroup right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        ///<inheritdoc/>
        public int UniqueId => _uniqueId;
        ///<inheritdoc/>
        public string Name {
            get
            {
                if (_isBaseGroup)
                    return Resource.BaseGroupDisplayName;
                return _displayName ?? string.Format(Resource.GroupName, _uniqueId);
            }
        }
        ///<inheritdoc/>        
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupName, true)]
        public string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupEmailAddress, false)]
        public string EmailAddress
        {
            get => _emailAddress;
            set => _emailAddress = value;
        }
        ///<inheritdoc/>
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
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupContainedGroups, false)]
        public abstract IGroups Groups { get; }
        ///<inheritdoc/>
        public abstract IGroups GroupsRecursive { get; }
        ///<inheritdoc/>
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
        ///<inheritdoc/>
        [AppFolderProperty(CoaApplicationFoldersProperties.GroupContainedUsers, true)]
        public abstract IUsers Users { get; }
        ///<inheritdoc/>
        public abstract IUsers UsersRecursive { get; }
        ///<inheritdoc/>
        public void Save()
        {
            if (_isBaseGroup)
                throw new CoaGroupModificationException();
            _uniqueId = OnSave();
        }
        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as IGroup);
        }
        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        ///<inheritdoc/>
        public bool Equals(IGroup other)
        {
            if (other == null)
                return false;
            return UniqueId == other.UniqueId;
        }
        ///<inheritdoc/>
        public void Delete()
        {
            if (_isBaseGroup)
                throw new CoaGroupModificationException();
            OnDelete();
        }
        ///<inheritdoc/>
        public abstract void AddGroup(IGroup group);
        ///<inheritdoc/>
        public abstract void AddUser(IUser user);
        ///<inheritdoc/>
        public abstract bool IsInGroup(string groupName);
        ///<inheritdoc/>
        public abstract bool IsInGroupRecursive(string groupName);
        ///<inheritdoc/>
        public abstract void RemoveGroup(IGroup group);
        ///<inheritdoc/>
        public abstract void RemoveUser(IUser user);
        ///<inheritdoc/>
        public abstract void SendEmail();
        /// <summary>
        /// Save method declaration
        /// </summary>
        /// <returns>Group id stored in database</returns>
        protected abstract int OnSave();
        /// <summary>
        /// Get user object method declaration
        /// </summary>
        /// <param name="objectId">Object unique Id</param>
        /// <returns>
        /// User Object
        /// <seealso cref="ICustomObject"/>
        /// </returns>
        protected abstract ICustomObject OnGetObject(long objectId);
        /// <summary>
        /// Delete method declaration
        /// </summary>
        protected abstract void OnDelete();
    }
}
