using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Repository.Database;
using FlexiObject.DbProvider.Entities;

namespace FlexiObject.API.Model
{
    public class User : AppBase, IUser
    {
        private readonly IUserDbRepository _dbRepository;
        private readonly ICustomObjectRepository _dbObjectRepository;
        private int _uniqueId;
        public User(Application app, object parent, IUserDbRepository repository, ICustomObjectRepository objRepository, AppUser contract = null) : base(app, parent)
        {
            _dbRepository  = repository;
            _dbObjectRepository = objRepository;

            if(contract == null)
                return;
            Active = contract.IsActive;
            Department = contract.Department;
            DisplayName = contract.DisplayName;
            Email = contract.Email;
            LoginName = contract.LoginName;
            LoginMode = contract.LoginMode;
            Phone= contract.Phone;
            Administrator = contract.IsAdministrator;
            _uniqueId = contract.Id;
        }
        
        public bool Active { get; set; }
        public ICustomFolder DefaultRequestFolder { get; set; }
        public string Department { get; set; }
        public string DisplayName { get; set; }
        public string DomainName { get; set; }
        public string Email { get; set; }
        public IGroups Groups => new Groups(Application, this, _dbRepository, false);
        public IGroups GroupsRecursive => new Groups(Application, this, _dbRepository, true);
        public bool HasDefaultCustomObjectFolder { get; set; }
        public string LoginName { get; set; }
        public string Name => GetName(_uniqueId, null);
        public ICustomObject Object => _dbObjectRepository.GetByUserId(UniqueId);
        public string OutgoingEmailAccount { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Administrator { get; set; }
        public int UniqueId => _uniqueId;
        public CoaUserAuthenticationTypes AuthenticationType { get; set; }
        public CoaUserAuthTypes LoginMode { get; set; }

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
