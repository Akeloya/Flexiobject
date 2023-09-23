using FlexiObject.Core.Enumes;

using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("AppFolders")]
    public class AppFolder
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public FlexiApplicationFolderTypes AppFolderId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
