using FlexiObject.DbProvider.Entities;

using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider
{
    [Table("ImportCmStps")]
    public partial class ImportCmSteps
    {
        public int Id { get; set; }
        public int ColMappingId { get; set; }
        public int FieldId { get; set; }
        public virtual ImportColMapping ColMapping { get; set; }
        public virtual FieldDefinition Field { get; set; }
    }
}
