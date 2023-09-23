using FlexiObject.DbProvider.Entities;

namespace FlexiObject.DbProvider
{
    public partial class Privilege
    {
        public int Id { get; set; }
        public byte Level { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
