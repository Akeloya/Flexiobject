using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ListProperties")]
    public partial class ListProperty
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public int FolderId { get; set; }
        public int FieldId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
