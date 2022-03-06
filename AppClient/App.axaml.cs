using AppClient.ViewModels;
using AppClient.Views;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using PropertyChanged;

namespace AppClient
{
    [DoNotNotify]
    public class App : Application
    {
        private readonly MainWindowViewModel _viewModel;
        public App() { }
        public App(MainWindowViewModel view)
        {
            _viewModel = view;
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
                    DataContext = _viewModel
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
