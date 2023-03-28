using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    [Table("FieldDefinitions")]
    public partial class FieldDefinition
    {
        public FieldDefinition()
        {
            ListProperties = new HashSet<ListProperty>();
            Status = new HashSet<WfState>();
            StateTransitions = new HashSet<WfStateTransition>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public FlexiFieldTypes Type { get; set; }
        public bool WriteHistory { get; set; }
        public virtual ObjectFolder FolderReference { get; set; }
        public int DataProperty { get; set; }
        public int QuicksearchField { get; set; }
        public int MinSize { get; set; }
        public int MaxSize { get; set; }
        public bool IndexDb { get; set; }
        public bool Restriction { get; set; }
        public bool RestrictionScript { get; set; }
        public int RestrictionScriptId { get; set; }
        public string RestrictionErrMsg { get; set; }
        public string RestrictionMutch { get; set; }
        public bool IsSyncronized { get; set; }
        public int FolderId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public virtual ICollection<ListProperty> ListProperties { get; set; }
        public virtual ICollection<WfState> Status { get; set; }
        public virtual ICollection<WfStateTransition> StateTransitions { get; set; }
    }
}
