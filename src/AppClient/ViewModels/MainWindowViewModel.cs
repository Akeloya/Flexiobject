using FlexiObject.API;
using FlexiObject.AppClient.Services;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        public static MainWindowViewModel Create => new(null, null, new Api());        
        public MainWindowViewModel(IDialogService dialog, INavigationService navigation, Api api) : base(dialog, api)
        {
            _navigation = navigation;
            StartTimer();
            var app = api.Create();
            app.OpenSession("localhost", 555, null, null);
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
