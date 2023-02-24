﻿using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Model.Object;
using FlexiObject.Core.Repository.Database;
using FlexiObject.Core.Repository.DataContracts;

namespace FlexiObject.Core
{
    public class User : AppBase, IUser
    {
        private readonly IUserDbRepository _dbRepository;
        private readonly ICustomObjectRepository _dbObjectRepository;
        private int _uniqueId;
        public User(Application app, object parent, IUserDbRepository repository, ICustomObjectRepository objRepository, UserDataContract contract = null) : base(app, parent)
        {
            _dbRepository  = repository;
            _dbObjectRepository = objRepository;

            if(contract == null)
                return;
            Active = contract.Active;
            Department = contract.Department;
            DisplayName = contract.DisplayName;
            EmailAddress = contract.EmailAddress;
            LastName= contract.LastName;
            LoginName = contract.LoginName;
            Phone= contract.Phone;
            Administrator = contract.Administrator;
            _uniqueId = contract.UniqueId;
        }
        
        public bool Active { get; set; }
        public ICustomFolder DefaultRequestFolder { get; set; }
        public string Department { get; set; }
        public string DisplayName { get; set; }
        public string DomainName { get; set; }
        public string EmailAddress { get; set; }
        public IGroups Groups => new Groups(Application, this, _dbRepository, false);
        public IGroups GroupsRecursive => new Groups(Application, this, _dbRepository, true);
        public bool HasDefaultCustomObjectFolder { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Name => GetName(_uniqueId, null);
        public ICustomObject Object => _dbObjectRepository.GetByUserId(UniqueId);
        public string OutgoingEmailAccount { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Administrator { get; set; }
        public int UniqueId => _uniqueId;
        public CoaUserAuthenticationTypes AuthenticationType { get; set; }

        public void AddToGroup(IGroup group)
        {
            _dbRepository.AddToGroup(this, group);
        }

        public void Delete()
        {
            _dbRepository.Delete(UniqueId);
        }

        public bool IsInGroup(string groupName)
        {
            return _dbRepository.IsInGroup(this, groupName, false);
        }

        public bool IsInGroupRecursive(string groupName)
        {
            return _dbRepository.IsInGroup(this, groupName, true);
        }

        public void Save()
        {
            var user = _dbRepository.Save(this);
            _uniqueId = user.UniqueId;
        }
    }
}
