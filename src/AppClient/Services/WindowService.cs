using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;
using FlexiObject.AppClient.Core.Window;
using FlexiObject.AppClient.ViewModels;
using FlexiObject.AppClient.Views;
using FlexiObject.Core.Config;
using FlexiObject.Core.Utilities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Services
{
    public class WindowService : IWindowService
    {
        private Window _current;
        private readonly IList<Window> _openedWindows = new List<Window>();
        private static readonly object _lock = new();
        private readonly ViewLocator _viewLocator;
        private readonly IContainer _container;
        public WindowService(IContainer container, ViewLocator viewLocator)
        {
            _container = container;
            _viewLocator = viewLocator;
        }
        public Window Current => _current;

        public Window CreateDefault(object model)
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

        public Window CreateDialog(object model)
        {

            return TaskHelper.RunSync(() =>
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var wnd = new DefaultWindow
                    {
                        Width = 400,
                        Height = 200,
                        CanResize = false,
                        WindowState = WindowState.Normal,
                        DataContext = model
                    };
                    wnd.Content = _viewLocator.Build(model);
                    wnd.Closed += WndClosed;
                    lock (_lock)
                    {
                        _openedWindows.Add(wnd);
                        return wnd;
                    }
                })
                );

        }

        public async Task<Window> CreateDialogAsync(object model)
        {
            return await Dispatcher.UIThread.InvokeAsync(() =>
            {
                var wnd = new DefaultWindow
                {
                    Width = 400,
                    Height = 200,
                    CanResize = false,
                    WindowState = WindowState.Normal,
                    DataContext = model,
                    Content = _viewLocator.Build(model)
                };
                wnd.Closed += WndClosed;
                lock (_lock)
                {
                    _openedWindows.Add(wnd);
                    return wnd;
                }
            });
        }

        private void WndClosed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                var wnd = (Window)sender;
                if (!_openedWindows.Remove(wnd))
                {
                    //throw new Exception();//TODO need idea how to catch window, that creates not from IWindowService
                }
            }
        }

        public async Task SetupMainWindowView(IScreen view)
        {
            if(Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    if(desktop.MainWindow == null)
                    {
                        desktop.MainWindow = _container.Get<IWindowService>().CreateDefault<MainWindowViewModel>();
                        return;
                    }
                    
                    desktop.MainWindow.DataContext = view;
                    desktop.MainWindow.Content = _viewLocator.Build(view);
                });
            }
        }
    }
}
