namespace FlexiObject.DbProvider.Entities
{
    public partial class SummaryAddFieldsStps
    {
        public int Id { get; set; }
        public int FieldDefId { get; set; }
        public int AddFieldId { get; set; }
        public virtual FieldDefinition FieldDef { get; set; }
        public virtual SummaryAddFields AddField { get; set; }
    }
}
