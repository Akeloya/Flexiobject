using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;
using FlexiObject.DbProvider.Entities;

using System;

namespace FlexiObject.API.Model
{
    public class Group : AppBase, IGroup
    {
        private readonly IUserRepository _dbRepository;
        private readonly ICustomObjectRepository _objRepo;
        private int _uniqueId;
        public Group(IApplication app, object parent, IUserRepository userDbRepository, ICustomObjectRepository objRepo, AppUser dbGroup = null) : base(app, parent)
        {
            _dbRepository = userDbRepository;
            _objRepo = objRepo;
            if(dbGroup != null )
            {
                DisplayName = dbGroup.DisplayName;
                EmailAddress = dbGroup.Email;
                _uniqueId = dbGroup.Id;
            }
        }
        public int UniqueId => _uniqueId;

        public string Name => GetName(_uniqueId,null);

        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public FlexiGroupBehaviorTypes EmailBehavior { get; set; }

        public IGroups Groups => new Groups(Application, this, _dbRepository, _objRepo);

        public IGroups GroupsRecursive => new Groups(Application, this, _dbRepository, _objRepo, true);

        public ICustomObject Object => _objRepo.GetByUserOrGroupId(_uniqueId);

        public IUsers Users => new Users(Application, this, _dbRepository, _objRepo);

        public IUsers UsersRecurcive => new Users(Application, this, _dbRepository, _objRepo, true);

        public void AddGroup(IGroup group)
        {
            _dbRepository.AddToGroup(this, group);
        }

        public void AddUser(IUser user)
        {
            _dbRepository.AddToGroup(this, user);
        }

        public void Delete()
        {
            _dbRepository.Delete(_uniqueId);
        }

        public bool IsInGroup(string groupName)
        {
            return _dbRepository.IsInGroup(this, groupName, false);
        }

        public bool IsInGroupRecursive(string groupName)
        {
            return _dbRepository.IsInGroup(this, groupName, true);
        }

        public void RemoveGroup(IGroup group)
        {
            _dbRepository.RemoveFromGroup(this, group);
        }

        public void RemoveUser(IUser user)
        {
            _dbRepository.RemoveFromGroup(this, user);
        }

        public void Save()
        {
            var result =_dbRepository.Save(this);
            _uniqueId = result.UniqueId;
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
