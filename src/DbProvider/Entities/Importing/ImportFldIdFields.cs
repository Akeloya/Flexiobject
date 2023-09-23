using FlexiObject.DbProvider.Entities;

namespace FlexiObject.DbProvider
{
    public partial class ImportFldIdFields
    {
        public int Id { get; set; }
        public int FldSettingsId { get; set; }
        public int FieldId { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
