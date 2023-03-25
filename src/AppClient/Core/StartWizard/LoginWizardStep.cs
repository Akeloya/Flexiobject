using FlexiObject.AppClient.Services;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Utilities;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.StartWizard
{
    internal class LoginWizardStep : IWindowWizardStep
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly IDialogService _dialogService;
        public LoginWizardStep(LoginViewModel loginViewModel, IDialogService dialogService)
        {
            _loginViewModel = loginViewModel;
            _dialogService = dialogService;
        }

        public ViewModelBase ViewModel => _loginViewModel;

        public string Name => "Show login view model";

        public bool IsBackground => false;

        public event EventHandler<ViewModelBase> OnSetupViewModel;

        public void Setup()
        {
            TaskHelper.RunSync(SetupAsync);
        }

        public async Task SetupAsync()
        {
            bool? loginResult = await _dialogService.ShowDialogAsync(_loginViewModel);

            if (loginResult != true)
                throw new WizardTerminateExeption();
        }
    }
}
