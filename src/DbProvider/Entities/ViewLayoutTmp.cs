namespace FlexiObject.DbProvider.Entities
{
    public partial class ViewLayoutTmp
    {
        public int Id { get; set; }
        public byte[] Layout { get; set; }
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        
    }
}
