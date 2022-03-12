using AppClient.Views;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using System;
using System.Collections.Concurrent;

namespace AppClient.Services
{
    public class WindowService : IWindowService
    {
        private readonly ConcurrentStack<Window> _openedWindows = new();
        private static readonly object _lock = new();
        private readonly IContainer _container;
        private readonly ViewLocator _viewLocator;
        public WindowService(IContainer container, ViewLocator viewLocator)
        {
            _container = container;
            _viewLocator = viewLocator;
        }
        public Window Current
        {
            get
            {
                if(_openedWindows.TryPeek(out Window window))
                    return window;
                return null;
            }
        }

        public Window CreateDefault()
        {
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>()!;
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://AppClient/Assets/avalonia-logo.ico")));
            lock (_lock)
            {
                var wnd = new DefaultWindow();
                wnd.DataTemplates.Add(_viewLocator);
                wnd.Closed += WndClosed;
                _openedWindows.Push(wnd);
                return wnd;
            }
        }

        public Window CreateDialog()
        {
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>()!;
            var bitmap = new Bitmap(assets.Open(new Uri($"avares://AppClient/Assets/avalonia-logo.ico")));
            lock (_lock)
            {
                var wnd = new DefaultWindow
                {
                    Width = 400,
                    Height = 200,
                    CanResize = false
                };
                wnd.DataTemplates.Add(_viewLocator);
                wnd.Closed += WndClosed;
                
                _openedWindows.Push(wnd);
                return wnd;
            }
        }

        public Window CreateDefault<T>()
        {
            var wnd = CreateDefault();
            var view = _container.Get<T>();
            wnd.Content = _viewLocator.Build(view);
            wnd.DataContext = view;
            return wnd;
        }
        private void WndClosed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                var wnd = (Window)sender;
                if (_openedWindows.TryPop(out Window window) && window != wnd)
                {
                    _openedWindows.Push(window);
                    throw new Exception();//TODO need idea how to catch window, that creates not from IWindowService
                }
            }
        }
    }
}
