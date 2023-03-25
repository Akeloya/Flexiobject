using FlexiObject.AppClient.Core;
using FlexiObject.AppClient.Core.Services;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        public static MainWindowViewModel Create => new(null);
        public MainWindowViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            StartTimer();
        }
        protected override void OnTimerTick()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");
        }

        public string OsVersion => Environment.OSVersion.Platform.ToString();
        public string CurrentTime { get; private set; }
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
