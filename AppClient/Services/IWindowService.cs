using Avalonia.Controls;

namespace AppClient.Services
{
    public interface IWindowService
    {
        Window Current { get; }
        Window CreateDefault();
        Window CreateDialog();
        Window CreateDefault<T>();
    }
}
