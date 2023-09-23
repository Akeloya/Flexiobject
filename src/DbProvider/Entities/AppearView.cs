namespace FlexiObject.DbProvider.Entities
{
    public partial class AppearView
    {
        public int Id { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
