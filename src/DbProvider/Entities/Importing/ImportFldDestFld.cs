using FlexiObject.DbProvider.Entities;

namespace FlexiObject.DbProvider
{
    public partial class ImportFldDestFld
    {
        public int Id { get; set; }
        public int FldSettingsId { get; set; }
        public int DestFolderId { get; set; }
        public virtual ObjectFolder DestFolder { get; set; }
    }
}
