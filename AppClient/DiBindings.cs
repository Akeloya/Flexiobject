using AppClient.Services;
using AppClient.ViewModels;

using Ninject;
using Ninject.Modules;

namespace AppClient
{
    internal class DiBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IContainer>().To<Container>().InSingletonScope();
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            RegisterViews(Kernel);
        }

        private static void RegisterViews(IKernel kernel)
        {
            kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            kernel.Bind<ViewModelBase>();
        }
    }
}
