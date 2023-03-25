using Avalonia.Controls;
using FlexiObject.AppClient.Core.Window;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Services
{
    public interface IWindowService
    {
        Window Current { get; }
        Window CreateDefault(object model);
        Window CreateDefault<T>() where T : IScreen;
        Window CreateDialog(object model);

        Task<Window> CreateDialogAsync(object model);
        Task SetupMainWindowView(IScreen view);
    }
}
