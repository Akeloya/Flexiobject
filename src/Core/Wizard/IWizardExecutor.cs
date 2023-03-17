using System.Threading.Tasks;

namespace FlexiObject.Core.Wizard
{
    public interface IWizardExecutor
    {
        void Setup();
        Task SetupAsync();
    }
}
