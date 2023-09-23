namespace FlexiObject.DbProvider
{
    public partial class FormProperty
    {
        public int Id { get; set; }
        public byte RefType { get; set; }
        public int Ref { get; set; }
        public string Name { get; set; }
        public int DataType { get; set; }
        public string Value { get; set; }
    }
}
