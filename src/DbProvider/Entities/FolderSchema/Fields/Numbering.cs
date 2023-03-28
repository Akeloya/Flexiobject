namespace FlexiObject.DbProvider.Entities
{
    public partial class Numbering
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public bool FillWithZeros { get; set; }
        public int? FieldWidth { get; set; }
        public string MinimumValue { get; set; }
        public bool ShareNumbers { get; set; }
        public int FolderId { get; set; }
        public int FieldId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
