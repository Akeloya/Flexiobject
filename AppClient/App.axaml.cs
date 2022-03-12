using AppClient.Services;
using AppClient.ViewModels;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace AppClient
{
    [DoNotNotify]
    public class App : Application
    {
        private readonly IWindowService _windowService;
        public App() { }
        public App(IWindowService windowService, IContainer container)
        {
            _windowService = windowService;
            DataTemplates.Add(new ViewLocator(container));
        }
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = _windowService.CreateDefault<MainWindowViewModel>();
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
