using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("SchemeFieldsDef")]
    public class SchemaFieldDefinition
    {
        public int Id { get; set; }
        public short FieldPosition { get; set; }
        public int FieldSize { get; set; }
        public string FieldName { get; set; }
        public short DataType { get; set; }
        public bool HasIndex { get; set; }
        public int SchemaDefId { get; set; }
        public virtual SchemeTableDefinition SchemeDef { get; set; }
    }
}
