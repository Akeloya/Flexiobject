using System;
using System.ComponentModel.DataAnnotations;

namespace FlexiObject.DbProvider.Entities
{
    public partial class DeletionLog
    {
        public int Id { get; set; }
        public long ObjectId { get; set; }
        public int FolderId { get; set; }
        [MaxLength(256)]
        public string ObjectName { get; set; }
        public DateTime DeletedTime { get; set; }
        [MaxLength(256)]
        public string DeletedBy { get; set; }
    }
}
