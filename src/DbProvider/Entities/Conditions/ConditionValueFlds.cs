using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ConditionValueFields")]
    public partial class ConditionValueFields
    {
        public int Id { get; set; }
        public virtual ConditionParam CondParams { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
