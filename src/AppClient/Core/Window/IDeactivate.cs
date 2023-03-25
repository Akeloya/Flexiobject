using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Window
{
    public interface IDeactivate
    {
        Task DeactivateAsync(bool close, CancellationToken token);
    }
}
