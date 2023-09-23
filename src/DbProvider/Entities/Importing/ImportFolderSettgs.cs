using FlexiObject.DbProvider.Entities;

namespace FlexiObject.DbProvider
{
    public partial class ImportFolderSettgs
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public short ImportType { get; set; }
        public bool UseCreationRule { get; set; }
        public bool CacheAllObjects { get; set; }
        public bool IncludeSubfolders { get; set; }
        public int? PerformanceFlags { get; set; }
        public int BulkSize { get; set; }
        public bool IgnoreBasefilter { get; set; }
        public bool CompatibilityFlag { get; set; }
        public bool IdFieldsNull { get; set; }
        public int FieldId { get; set; }
        public int SettingId { get; set; }
        public virtual ImportSettings Setting { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
