using Avalonia.Controls;
using FlexiObject.AppClient.Core;

namespace FlexiObject.AppClient.Services
{
    public interface IWindowService
    {
        Window Current { get; }
        Window CreateDefault(IClosableWnd model);
        Window CreateDefault<T>() where T : IClosableWnd;
        Window CreateDialog(IClosableWnd model);
    }
}
