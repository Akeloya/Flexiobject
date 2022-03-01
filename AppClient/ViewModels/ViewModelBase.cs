using AppClient.Services;

using ReactiveUI;


namespace AppClient.ViewModels
{
    public class ViewModelBase : ReactiveObject, IClosableWnd
    {
        protected IDialogService DialogService { get; set; }
        public ViewModelBase(IDialogService dialog)
        {
            DialogService = dialog;
        }

        public bool CloseWindow { get; set; }        
        public void Close()
        {
            CloseWindow = true;
        }
    }
}
