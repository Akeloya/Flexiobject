using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.UI
{
    public interface IUpdatableView
    {
        Task ApplyAsync();
        void Apply();
        void Discard();
    }
}
