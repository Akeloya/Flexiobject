using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("WfStateTransitions")]
    public class WfStateTransition
    {
        public int Id { get; set; }
        public int Old { get; set; }
        public int New { get; set; }
        public int FolderId { get; set; }
        public int FieldId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
