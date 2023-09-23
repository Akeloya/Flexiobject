using FlexiObject.Core.Wizard;
using FlexiObject.DbProvider;

using System.Threading.Tasks;

namespace FlexiObject.API.Setup
{
    internal class BaseSetupDbStep : IWizardStep
    {
        protected BaseSetupDbStep(string stepName, AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
            Name = stepName;
        }

        public string Name { get; }

        public bool IsBackground => false;

        protected AppDbContext AppDbContext { get; private set; }
        public virtual Task SetupAsync()
        {
            return Task.CompletedTask;
        }
    }
}
