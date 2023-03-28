using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    public partial class Script
    {
        public int Id { get; set; }
        public FlexiScriptTypes Type { get; set; }
        public string Name { get; set; }
        public string ScriptCode { get; set; }
        public int? Ref { get; set; }
        public byte? NumParams { get; set; }
        public bool DetermFldsValid { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
