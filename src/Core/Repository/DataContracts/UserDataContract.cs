using System;

namespace FlexiObject.Core.Repository.DataContracts
{
    [Serializable]
    public class UserDataContract
    {
        public int UniqueId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int? DefaultRequestFolder { get; set; }
        public string Department { get; set; }
        public string DisplayName { get; set; }
        public string DomainName { get; set; }
        public string EmailAddress { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public long ObjectId{get;set; }
        public string Phone { get; set; }
        public bool Administrator { get; set; }
    }
}
