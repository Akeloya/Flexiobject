using Avalonia;

using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;

using FlexiObject.AppClient.Core.Window;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.AppClient.Views;
using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Utilities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services.Windows
{
    using Avalonia.Controls;
    public class WindowService : IWindowService
    {
        private Window _current;
        private readonly IList<Window> _openedWindows = new List<Window>();
        private static readonly object _lock = new();
        private readonly ViewLocator _viewLocator;
        private readonly IContainer _container;
        private readonly ILogger _logger;
        public WindowService(IContainer container, ViewLocator viewLocator, LoggerFactory loggerFactory)
        {
            _container = container;
            _viewLocator = viewLocator;
            _logger = loggerFactory.Create<WindowService>();
        }
        public Window Current => _current;

        public Window CreateDefault(IScreen model)
        {
            var wnd = new DefaultWindow
            {
                DataContext = model,
                Content = _viewLocator.Build(model),
                WindowState = WindowState.Minimized
            };
            wnd.Closed += WndClosed;
            wnd.GotFocus += WndGotFocus;
            lock (_lock)
            {
                _openedWindows.Add(wnd);
                return wnd;
            }
        }
        public Window CreateDefault<T>() where T : IScreen
        {
            var view = _container.Get<T>();
            return CreateDefault(view);
        }

        private void WndGotFocus(object sender, Avalonia.Input.GotFocusEventArgs e)
        {
            _current = (Window)sender;
        }

        public Window CreateDialog(object model, DialogProperties properties = default)
        {
            return TaskHelper.RunSync(() =>
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var wnd = new DefaultWindow
                    {
                        WindowState = WindowState.Normal,
                        DataContext = model,
                        Content = _viewLocator.Build(model),
                        SizeToContent = SizeToContent.WidthAndHeight
                    };
                    SetupProperties(wnd, properties);
                    wnd.Closed += WndClosed;
                    lock (_lock)
                    {
                        _openedWindows.Add(wnd);
                        return wnd;
                    }
                })
                );

        }

        public async Task<Window> CreateDialogAsync(object model, DialogProperties properties = default)
        {
            return await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var wnd = new DefaultWindow
                {
                    WindowState = WindowState.Normal,
                    DataContext = model,
                    Content = _viewLocator.Build(model),
                    SizeToContent = SizeToContent.WidthAndHeight
                };
                SetupProperties(wnd, properties);
                wnd.Closed += WndClosed;
                lock (_lock)
                {
                    _openedWindows.Add(wnd);
                    return wnd;
                }
            });
        }

        public async Task SetupMainWindowView(IScreen view)
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if (desktop.MainWindow == null)
                    {
                        desktop.MainWindow = _container.Get<IWindowService>().CreateDefault<MainWindowViewModel>();
                        return;
                    }

                    desktop.MainWindow.DataContext = view;
                    desktop.MainWindow.Content = _viewLocator.Build(view);
                });
            }
        }

        private static void SetupProperties(DefaultWindow wnd, DialogProperties properties)
        {
            if (properties == null)
                return;

            if (!string.IsNullOrWhiteSpace(properties.Title))
                wnd.Title = properties.Title;
            if (properties.Height.HasValue)
                wnd.Height = properties.Height.Value;
            if (properties.Width.HasValue)
                wnd.Width = properties.Width.Value;
            if (properties.MinWidth.HasValue)
                wnd.MinWidth = properties.MinWidth.Value;
            if (properties.MaxWidth.HasValue)
                wnd.MaxWidth = properties.MaxWidth.Value;
            if (properties.MinHeight.HasValue)
                wnd.MinHeight = properties.MinHeight.Value;
            if (properties.MaxHeight.HasValue)
                wnd.MaxHeight = properties.MaxHeight.Value;
        }
        private void WndClosed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                var wnd = (Window)sender;
                if (!_openedWindows.Remove(wnd))
                {
                    _logger.Warn("Window was created outside service");
                    //throw new Exception();//TODO need idea how to catch window, that creates not from IWindowService
                }
            }
        }
    }
}
