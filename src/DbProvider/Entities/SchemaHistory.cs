using System;

namespace FlexiObject.DbProvider.Entities
{
    public partial class SchemaHistory
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Reference { get; set; }
        public DateTime EventDate { get; set; }
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public byte Action { get; set; }
        public int DeletedReference { get; set; }
        public int DeletedArea { get; set; }
        public string Version { get; set; }
        public string IpAddress { get; set; }
        public string Username { get; set; }
    }
}
