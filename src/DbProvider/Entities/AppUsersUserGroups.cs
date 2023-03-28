using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("AppUsers_UsersGroups")]
    public partial class AppUsersUserGroups
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual AppUser UserGroup { get; set; }
    }
}
