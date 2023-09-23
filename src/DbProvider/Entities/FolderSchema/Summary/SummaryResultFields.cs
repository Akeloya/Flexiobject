namespace FlexiObject.DbProvider.Entities
{
    public partial class SummaryResultFields
    {
        public int Id { get; set; }
        public int SummaryDefId { get; set; }
        public virtual FieldDefinition FieldDef { get; set; }
        public virtual SummaryDefinition SummaryDef { get; set; }
    }
}
