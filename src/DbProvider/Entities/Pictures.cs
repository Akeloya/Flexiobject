using System.ComponentModel.DataAnnotations.Schema;

namespace FlexiObject.DbProvider.Entities
{
    [Table("Pictures")]
    public class Picture
    {
        public int Id { get;  set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public bool IsIcon { get; set; }
    }
}
