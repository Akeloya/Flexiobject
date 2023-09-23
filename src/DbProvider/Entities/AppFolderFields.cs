using FlexiObject.Core.Enumes;

using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("AppFolderFields")]
    public class AppFolderField
    {
        public int Id { get; set; }
        public int FolderFieldId { get; set; }
        public virtual AppFolder AppFolder { get; set; }
        public FlexiApplicationFoldersProperties AppField { get; set; }
        public virtual FieldDefinition FolderField { get; set; }
    }
}
