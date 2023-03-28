namespace FlexiObject.DbProvider
{
    public partial class ImportColMapping
    {
        public int Id { get; set; }
        public int SettingsId { get; set; }
        public string Source { get; set; }
        public int Dest { get; set; }
        public byte Flags { get; set; }
        public byte AttachmentOption { get; set; }
    }
}
