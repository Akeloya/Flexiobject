using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("Rules")]
    public partial class Rule
    {
        public int Id { get; set; }
        public byte RuleType { get; set; }
        public int RefId { get; set; }
    }
}
