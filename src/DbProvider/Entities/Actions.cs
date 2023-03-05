using System.ComponentModel.DataAnnotations.Schema;

using FlexiObject.Core.Enumes;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ModifyActions")]
    public partial class ModifyAction
    {
        public int Id { get; set; }
        public FlexiActionListType ActionType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Expression { get; set; }
        public string Script { get; set; }
        public int FolderId { get; set; }
        public virtual ObjectFolder Folder { get; set; }
    }
}
