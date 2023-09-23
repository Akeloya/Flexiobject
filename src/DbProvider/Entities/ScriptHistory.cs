using System;

namespace FlexiObject.DbProvider.Entities
{
    public partial class ScriptHistory
    {
        public int Id { get; set; }
        public virtual Script SourceScript { get; set; }
        public string Script { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public int? PublishedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Published { get; set; }
        public bool IsPublished { get; set; }
    }
}
