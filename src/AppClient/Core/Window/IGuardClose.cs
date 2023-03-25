using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Window
{
    public interface IGuardClose : IClose
    {
        Task<bool> CanCloseAsync(CancellationToken cancellationToken = default);
    }
}
