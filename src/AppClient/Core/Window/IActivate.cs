using ReactiveUI;

using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Window
{
    public interface IActivate
    {
        bool IsActive { get; }

        Task ActivateAsync(CancellationToken token = default);
    }
}
