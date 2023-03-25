namespace FlexiObject.AppClient.Core.Services.Windows
{
    public class DialogProperties
    {
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string Title { get; set; }
        public int? MaxWidth { get; set; }
        public int? MaxHeight { get; set; }
        public int? MinWidth { get; set; }
        public int? MinHeight { get; set; }
    }
    public class DialogPropertyBuilder
    {
        private readonly DialogProperties dialogProperties = new();
        public DialogProperties Build() => dialogProperties;

        public DialogPropertyBuilder Width(int width)
        {
            dialogProperties.Width = width;
            return this;
        }

        public DialogPropertyBuilder Height(int height)
        {
            dialogProperties.Height = height;
            return this;
        }
        public DialogPropertyBuilder MinWidth(int minWidth)
        {
            dialogProperties.MinWidth = minWidth;
            return this;
        }

        public DialogPropertyBuilder MinHeight(int minHeight)
        {
            dialogProperties.MinHeight = minHeight;
            return this;
        }

        public DialogPropertyBuilder MaxWidth(int maxWidth)
        {
            dialogProperties.MaxWidth = maxWidth;
            return this;
        }

        public DialogPropertyBuilder MinMaxWidth(int width)
        {
            dialogProperties.MinWidth = dialogProperties.MaxWidth = width;
            return this;
        }

        public DialogPropertyBuilder MinMaxHeight(int height)
        {
            dialogProperties.MinHeight = dialogProperties.MaxHeight = height;
            return this;
        }

        public DialogPropertyBuilder WithTitle(string title)
        {
            dialogProperties.Title = title;
            return this;
        }
    }
}
