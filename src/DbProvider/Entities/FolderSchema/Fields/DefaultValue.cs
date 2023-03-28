using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("DefaultValues")]
    public partial class DefaultValue
    {
        public int Id { get; set; }
        public byte Type { get; set; }
        public long? ValBigint { get; set; }
        public string ValStr { get; set; }
        public int UserFieldId { get; set; }
        public int FolderId { get; set; }
        public virtual FieldDefinition UserField { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
