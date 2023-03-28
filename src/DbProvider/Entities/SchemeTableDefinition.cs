using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("SchemeTableDef")]
    public class SchemeTableDefinition
    {
        public int Id { get; set; }        
        public string TableName { get; set; }
        public bool Deleted { get; set; }
    }
}
