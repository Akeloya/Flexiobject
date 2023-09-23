namespace FlexiObject.DbProvider.Entities
{
    public partial class WindowLayout
    {
        public int Id { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Left { get; set; }
        public int? Top { get; set; }
        public bool? Maximized { get; set; }
        public byte[] PanesStream { get; set; }
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }
    }
}
