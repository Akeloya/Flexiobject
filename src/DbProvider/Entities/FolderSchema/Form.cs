namespace FlexiObject.DbProvider.Entities
{
    public partial class Form
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
