using System.ComponentModel.DataAnnotations.Schema;
using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    [Table("Conditions")]
    public partial class Condition
    {
        public int Id { get; set; }
        public int Rule { get; set; }
        public FlexiRuleCombinationTerms Operator { get; set; }
        public Condition Parent { get; set; }
        public byte Property { get; set; }
        public int KeyProperty { get; set; }
        public FlexiRuleComparisonsTypes Comparison { get; set; }
        public string ParamName { get; set; }
        public bool? MatchAll { get; set; }
        public byte? PropertyFlag { get; set; }
        public short? ParamPos { get; set; }
    }
}
