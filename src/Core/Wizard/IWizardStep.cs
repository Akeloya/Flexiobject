using System.Threading.Tasks;

namespace FlexiObject.Core.Wizard
{
    public interface IWizardStep
    {
        string Name { get; }
        bool IsBackground { get; }
        void Setup();
        Task SetupAsync();
    }
}
