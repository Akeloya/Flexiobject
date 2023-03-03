using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ObjHistory")]
    public partial class History
    {
        public int Id { get; set; }
        public DateTime ChangeDate { get; set; }
        public byte Attribute { get; set; }
        public int? UserField { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int State { get; set; }
        public byte Format { get; set; }
        public long ObjectId { get; set; }
        public int ModifiedById { get; set; }
        public virtual ObjectDef Object { get; set; }
        public virtual AppUser ModifiedBy { get; set; }
    }
}
