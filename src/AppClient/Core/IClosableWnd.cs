using Avalonia.Controls;

namespace FlexiObject.AppClient.Core
{
    public interface IClosableWnd
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool CanResize { get; set; }
        public WindowState SizeState { get; set; }
        public bool CloseWindow { get; set; }
        public void Close();
    }
}
