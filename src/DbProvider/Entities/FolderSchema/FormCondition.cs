using FlexiObject.DbProvider.Entities;

namespace FlexiObject.DbProvider
{
    public partial class FormCondition
    {
        public int Id { get; set; }
        public virtual ObjectFolder Folder { get; set; }
        public short Position { get; set; }
        public Form Form { get; set; }
        public bool Object { get; set; }
        public string Name { get; set; }
    }
}
