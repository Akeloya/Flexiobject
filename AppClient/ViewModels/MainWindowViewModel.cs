using Avalonia.Threading;

using FlexiObject.AppClient.Services;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        private readonly DispatcherTimer _dispatcherTimer;
        public static MainWindowViewModel Create => new(null, null);        
        public MainWindowViewModel(IDialogService dialog, INavigationService navigation) : base(dialog)
        {
            _navigation = navigation;
            _dispatcherTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (_,_) =>
            {
                CurrentTime = DateTime.Now.ToString("HH:mm:ss");
            });
            _dispatcherTimer.Start();
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
