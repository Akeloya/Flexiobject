namespace FlexiObject.DbProvider.Entities
{
    public partial class SynchRefFields
    {
        public int Id { get; set; }
        public byte SynchOption { get; set; }
        public int FieldId { get; set; }
        public int PartnerFieldId { get; set; }
        public virtual FieldDefinition Field { get; set; }
        public virtual FieldDefinition PartnerField { get; set; }
        
    }
}
