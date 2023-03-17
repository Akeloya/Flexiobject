using FlexiObject.Core.Wizard;

using System;

namespace FlexiObject.AppClient.Core
{
    internal interface IWindowWizardStep : IWizardStep
    {
        ViewModelBase ViewModel { get; }
        event EventHandler<ViewModelBase> OnSetupViewModel;
    }
}
