using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Window
{
    public interface IClose
    {
        Task TryCloseAsync(bool? dialogResult = null);
    }
}
