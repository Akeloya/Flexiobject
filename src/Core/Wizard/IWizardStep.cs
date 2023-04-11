using System.Threading.Tasks;

namespace FlexiObject.Core.Wizard
{
    /// <summary>
    /// Application wizard to setup app and environment
    /// </summary>
    public interface IWizardStep
    {
        string Name { get; }
        bool IsBackground { get; }
        Task SetupAsync();
    }
}
