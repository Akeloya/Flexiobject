using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

using FlexiObject.AppClient.Services;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.Core.Config;
using FlexiObject.Core.Wizard;

using PropertyChanged;

using System.Threading.Tasks;

using Application = Avalonia.Application;

namespace FlexiObject.AppClient
{
    [DoNotNotify]
    public class App : Application
    {
        private readonly IContainer _container;
        public App() { }
        public App(IContainer container)
        {
            _container = container;
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
                desktop.Startup += DesktopStartup;
                desktop.Exit += DesktopExit;
                desktop.ShutdownRequested += DesktopShutdownRequested;
                desktop.MainWindow = _container.Get<IWindowService>().CreateDefault<MainWindowViewModel>();
            }

            base.OnFrameworkInitializationCompleted();
            var wizardExecutor = _container.Get<IWizardExecutor>();
            Task.Run(async () =>
            {
                try
                {
                    await wizardExecutor.SetupAsync();
                }
                catch
                {
                    ((IClassicDesktopStyleApplicationLifetime)Current.ApplicationLifetime).Shutdown();
                }
            });
        }

        private void DesktopShutdownRequested(object sender, ShutdownRequestedEventArgs e)
        {
        }

        private void DesktopExit(object sender, ControlledApplicationLifetimeExitEventArgs e)
        {
        }

        private void DesktopStartup(object sender, ControlledApplicationLifetimeStartupEventArgs e)
        {
        }
    }
}
