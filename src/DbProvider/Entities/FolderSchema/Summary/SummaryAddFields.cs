using System.Collections.Generic;

namespace FlexiObject.DbProvider.Entities
{
    public partial class SummaryAddFields
    {
        public SummaryAddFields()
        {
            SummaryAddFieldsStps = new HashSet<SummaryAddFieldsStps>();
        }

        public int Id { get; set; }
        public int SummaryDefId { get; set; }
        public int FieldId { get; set; }
        public virtual SummaryDefinition SummaryDef { get; set; }
        public virtual FieldDefinition Field { get; set; }
        public virtual ICollection<SummaryAddFieldsStps> SummaryAddFieldsStps { get; set; }
    }
}
