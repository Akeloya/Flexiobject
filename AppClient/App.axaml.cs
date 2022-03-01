using AppClient.ViewModels;
using AppClient.Views;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using Ninject;

using PropertyChanged;

namespace AppClient
{
    [DoNotNotify]
    public class App : Application
    {
        private readonly static IKernel _kernel;
        public static IKernel Kernel => _kernel;
        static App()
        {
            _kernel = new StandardKernel();
        }
        public App()
        {
            Bootstrapper.Register(_kernel);
        }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = _kernel.Get<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
