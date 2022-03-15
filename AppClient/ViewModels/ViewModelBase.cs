using Avalonia.Controls;

using FlexiObject.AppClient.Services;

using ReactiveUI;


namespace FlexiObject.AppClient.ViewModels
{
    public class ViewModelBase : ReactiveObject, IClosableWnd
    {
        protected IDialogService DialogService { get; set; }
        public ViewModelBase(IDialogService dialog)
        {
            DialogService = dialog;
        }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public bool CloseWindow { get; set; }
        public bool CanResize { get; set; } = true;
        public WindowState SizeState { get; set; } = WindowState.Maximized;

        public void Close()
        {
            CloseWindow = true;
        }
    }
}
