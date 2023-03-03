using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("ObjectDef")]
    public class ObjectDef
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public int FolderId { get; set; }
        public int UserDeletedById { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public ICollection<History> HistoryList { get; set; }

        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}
