using AppClient.Services;
using AppClient.ViewModels;
using AppClient.Views;

using Ninject;
using Ninject.Modules;

using NLog;

namespace AppClient
{
    internal class DiBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<LogFactory>().ToSelf().InSingletonScope();

            Bind<IContainer>().To<Container>().InSingletonScope();
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IJsonConfiguration>().To<JsonConfiguration>().InSingletonScope();

            Bind<IWindowService>().To<WindowService>().InSingletonScope();

            RegisterViews(Kernel);
        }

        private static void RegisterViews(IKernel kernel)
        {
            kernel.Bind<MainWindowView>().ToSelf().InSingletonScope();
            kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<ViewModelBase>();
        }
    }
}
