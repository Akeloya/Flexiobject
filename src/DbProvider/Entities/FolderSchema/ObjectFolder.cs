using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ObjectFolder")]
    public class ObjectFolder
    {
        public ObjectFolder()
        {
            FieldDefinitions = new HashSet<FieldDefinition>();
            SummaryDefinition = new HashSet<SummaryDefinition>();
            ListProperties = new HashSet<ListProperty>();
            WfStates = new HashSet<WfState>();
            HistoriEntries = new HashSet<SchemaHistory>();
            WfStateTransitions = new HashSet<WfStateTransition>();
            Actions = new HashSet<ModifyAction>();
        }
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string NamingScheme { get; set; }
        public bool InheritNs { get; set; }
        public int ParentId { get; set; }
        public int OpenPictureId { get; set; }
        public int ClosePictureId { get; set; }
        public int? WfHistoryFieldId { get; set; }
        public virtual Picture PictureOpen { get; set; }
        public virtual Picture PictureClose { get; set; }
        [NotMapped]
        public WfState WfHistoryField { get; set; }
        public virtual ObjectFolder Parent { get; set; }
        public virtual ICollection<FieldDefinition> FieldDefinitions { get; set; }
        public virtual ICollection<SummaryDefinition> SummaryDefinition { get; set; }
        public virtual ICollection<ListProperty> ListProperties { get; set; }
        public virtual ICollection<WfState> WfStates { get; set; }
        public virtual ICollection<ObjectDef> Objects { get; set; }
        public virtual ICollection<SchemaHistory> HistoriEntries { get; set; }
        public virtual ICollection<Privilege> Privileges { get; set; }
        public virtual ICollection<WfStateTransition> WfStateTransitions { get; set; }
        public virtual ICollection<ModifyAction> Actions { get; set; }
    }
}
