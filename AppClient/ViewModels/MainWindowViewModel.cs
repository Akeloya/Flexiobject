using AppClient.Services;

namespace AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static MainWindowViewModel Create => new MainWindowViewModel(null);
        public MainWindowViewModel(IDialogService dialog): base(dialog)
        {
        }
        public void Help()
        {
            DialogService.ShowQuestionDialog("information");
        }
    }
}
