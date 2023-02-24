using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;

using System;

namespace FlexiObject.API.Model
{
    public class Group : AppBase, IGroup
    {
        private IUserDbRepository _dbRepository;
        internal protected Group(IApplication app, object parent, IUserDbRepository userDbRepository) : base(app, parent)
        {
            _dbRepository = userDbRepository;
        }
        public int UniqueId => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string DisplayName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CoaGroupBehaviorTypes EmailBehavior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGroups Groups => new Groups(Application, this, _dbRepository);

        public IGroups GroupsRecursive => throw new NotImplementedException();

        public ICustomObject Object => throw new NotImplementedException();

        public IUsers Users => throw new NotImplementedException();

        public IUsers UsersRecurcive => throw new NotImplementedException();

        public void AddGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public bool IsInGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public bool IsInGroupRecursive(string groupName)
        {
            throw new NotImplementedException();
        }

        public void RemoveGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
