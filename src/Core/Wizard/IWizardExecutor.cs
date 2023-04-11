using System.Threading.Tasks;

namespace FlexiObject.Core.Wizard
{
    public interface IWizardExecutor
    {
        Task SetupAsync();
    }
}
