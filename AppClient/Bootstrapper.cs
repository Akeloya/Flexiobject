using AppClient.Services;
using AppClient.ViewModels;

using Ninject;

namespace AppClient
{
    public static class Bootstrapper
    {
        public static void Register(IKernel kernel)
        {            
            kernel.Bind<IDialogService>().To<DialogService>().InSingletonScope();
            RegisterViews(kernel);
        }

        private static void RegisterViews(IKernel kernel)
        {
            kernel.Bind<ViewModelBase>();
        }
    }
}
