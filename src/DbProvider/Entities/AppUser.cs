using System;
using System.ComponentModel.DataAnnotations.Schema;

using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    [Table("AppUsers")]
    public partial class AppUser
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public bool IsAdministrator { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsGroup { get; set; }
        public byte GroupMail { get; set; }
        public bool IsActive { get; set; }
        public CoaUserAuthTypes LoginMode { get; set; }
        public string DomainName { get; set; }
        public long? ObjectId { get; set; }
        public DateTime? Modified { get; set; }
        public virtual ObjectDef Object { get; set; }
    }
}
