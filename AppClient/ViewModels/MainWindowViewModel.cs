using AppClient.Services;

using System;
using System.Threading.Tasks;

namespace AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        public static MainWindowViewModel Create => new(null, null);
        public MainWindowViewModel(IDialogService dialog, INavigationService navigation) : base(dialog)
        {
            _navigation = navigation;
        }
        public Task Help()
        {
            return DialogService.OpenFileDialogAsync(false);
            //DialogService.ShowQuestionDialog(Environment.OSVersion.ToString());
        }

        public void About()
        {
            _navigation.Navigate<AboutAppViewModel>();
        }

        public void Settings()
        {
            _navigation.Navigate<SettingsViewModel>();
        }

        public void OpenSetupFolder()
        {
            DialogService.OpenSetupFolder();
        }
    }
}
