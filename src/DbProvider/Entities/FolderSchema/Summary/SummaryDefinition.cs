using System.Collections.Generic;

namespace FlexiObject.DbProvider.Entities
{
    public partial class SummaryDefinition
    {
        public SummaryDefinition()
        {
            SummaryAddFields = new HashSet<SummaryAddFields>();
            SummaryFieldSteps = new HashSet<SummaryFieldSteps>();
            SummaryResultFields = new HashSet<SummaryResultFields>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
        public int? RefField { get; set; }
        public int? ScriptId { get; set; }
        public int? ModifObjFlags { get; set; }
        public bool? RecalcAfterRemove { get; set; }
        public bool? StoreZero { get; set; }
        public int FolderId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual ICollection<SummaryAddFields> SummaryAddFields { get; set; }
        public virtual ICollection<SummaryFieldSteps> SummaryFieldSteps { get; set; }
        public virtual ICollection<SummaryResultFields> SummaryResultFields { get; set; }
    }
}
