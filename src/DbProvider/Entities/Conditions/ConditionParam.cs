using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ConditionParams")]
    public partial class ConditionParam
    {
        public int Id { get; set; }
        public ObjectDef Object { get; set; }
        public Condition Condition { get; set; }
        public byte Value { get; set; }
        public long LongValue { get; set; }
        public string StrValue { get; set; }
        public double DoubleValue { get; set; }
        public int LongValueHigh { get; set; }
        public byte ObjectType { get; set; }
    }
}
