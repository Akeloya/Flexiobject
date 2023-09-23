namespace FlexiObject.DbProvider.Entities
{
    public partial class UserFieldProp
    {
        public int Id { get; set; }
        public virtual FieldDefinition Field { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public bool Flag { get; set; }
        public byte Type { get; set; }
        public bool UseScript { get; set; }
        public int Script { get; set; }
    }
}
