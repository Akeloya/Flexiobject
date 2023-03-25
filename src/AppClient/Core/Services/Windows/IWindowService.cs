using Avalonia.Controls;

using FlexiObject.AppClient.Core.Window;

using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services.Windows
{
    public interface IWindowService
    {
        Window Current { get; }
        Window CreateDefault(IScreen model);
        Window CreateDefault<T>() where T : IScreen;
        Window CreateDialog(object model, DialogProperties properties = default);
        Task<Window> CreateDialogAsync(object model, DialogProperties properties = default);
        Task SetupMainWindowView(IScreen view);
    }
}
