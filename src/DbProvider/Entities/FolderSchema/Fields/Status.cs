using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("WfStatus")]
    public partial class WfState
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Initial { get; set; }
        public string Alias { get; set; }
        public int FolderId { get; set; }
        public int FieldId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
