namespace FlexiObject.DbProvider
{
    public partial class ImportSettings
    {
        public int Id { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string SqlStatement { get; set; }
        public int User { get; set; }
        public short DataSourceType { get; set; }
        public bool LogErrors { get; set; }
        public string LogfilePrefix { get; set; }
        public string Logpath { get; set; }
        public bool UseSql { get; set; }
        public short Flags { get; set; }
        public bool ReflistFull { get; set; }
        public bool RemoveRefs { get; set; }
        public string IdColumns { get; set; }
    }
}
