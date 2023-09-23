using FlexiObject.API.Setup;

using System;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.StartWizard
{
    internal class SetupDatabaseWizardStep : IWindowWizardStep
    {
        private readonly SetupEmptyDatabaseWizardStep _setupEmptyDatabaseWizardStep;

        public SetupDatabaseWizardStep(SetupEmptyDatabaseWizardStep setupEmptyDatabaseWizardStep)
        {
            _setupEmptyDatabaseWizardStep = setupEmptyDatabaseWizardStep;
        }
        public ViewModelBase ViewModel => throw new NotImplementedException();

        public string Name => _setupEmptyDatabaseWizardStep.Name;

        public bool IsBackground => _setupEmptyDatabaseWizardStep.IsBackground;

        public event EventHandler<ViewModelBase> OnSetupViewModel;

        public Task SetupAsync()
        {
            return _setupEmptyDatabaseWizardStep.SetupAsync();
        }
    }
}
