using FlexiObject.AppClient.Services;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.Core.Exceptions;
using FlexiObject.Core.Utilities;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.StartWizard
{
    internal class LoginWizardStep : IWindowWizardStep
    {
        private readonly IWindowService _windowService;
        private readonly LoginViewModel _loginViewModel;
        public LoginWizardStep(IWindowService windowService, LoginViewModel loginViewModel)
        {
            _windowService = windowService;
            _loginViewModel = loginViewModel;
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
            var manualEvent = new ManualResetEvent(false);
            var loginResult = false;
            _loginViewModel.LoginCompleted += (_, result) =>
            {
                loginResult = result;
                manualEvent.Set();
                manualEvent.Dispose();
            };
            await _windowService.SetupMainWindowView(_loginViewModel);
            manualEvent.WaitOne();
            if (!loginResult)
                    throw new WizardTerminateExeption();
        }
    }
}
