using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ConditionSteps")]
    public partial class ConditionStps
    {
        public int Id { get; set; }
        public Condition Condition { get; set; }
        public FieldDefinition UserField { get; set; }
    }
}
