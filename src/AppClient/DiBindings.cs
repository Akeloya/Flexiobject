﻿using FlexiObject.Core.Config;
using FlexiObject.AppClient.UI.Views;

using Ninject;

using NLog;
using FlexiObject.AppClient.Core;
using FlexiObject.Core.Wizard;
using FlexiObject.AppClient.Core.StartWizard;
using FlexiObject.AppClient.Core.Services.Windows;
using FlexiObject.AppClient.Core.Services;
using FlexiObject.AppClient.UI.ViewModels;

namespace FlexiObject.AppClient
{
    internal class AppBindings : DiBindings
    {
        public override void Load()
        {
            base.Load();
            Bind<LogFactory>().ToSelf().InSingletonScope();
            
            Bind<INavigationService>().To<NavigationService>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IJsonConfiguration>().To<JsonConfiguration>().InSingletonScope();

            Bind<IWindowService>().To<WindowService>().InSingletonScope();

            Bind<ApiFactory>().ToSelf().InSingletonScope();

            Bind<IWizardExecutor>().To<WizardExecutor>().InSingletonScope();
            Bind<IWizardStep>().To<LoginWizardStep>().InSingletonScope();
            Bind<IWizardStep>().To<SetupMainWindowStep>().InSingletonScope();

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
