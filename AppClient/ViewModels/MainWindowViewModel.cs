using AppClient.Services;

namespace AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        public static MainWindowViewModel Create => new MainWindowViewModel(null, null);
        public MainWindowViewModel(IDialogService dialog, INavigationService navigation) : base(dialog)
        {
            _navigation = navigation;
        }
        public void Help()
        {
            DialogService.ShowQuestionDialog("information");
        }

        public void About()
        {
            _navigation.Navigate<AboutAppViewModel>();
        }
    }
}
