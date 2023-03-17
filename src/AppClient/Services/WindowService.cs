using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Threading;

using FlexiObject.AppClient.Core;
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

        public Window CreateDefault(IClosableWnd model)
        {
            var wnd = new DefaultWindow
            {
                DataContext = model,
                Content = _viewLocator.Build(model),
                Width = model.Width,
                Height = model.Height,
                WindowState = model.SizeState
            };
            wnd.Closed += WndClosed;
            wnd.GotFocus += WndGotFocus;
            lock (_lock)
            {
                _openedWindows.Add(wnd);
                return wnd;
            }
        }
        public Window CreateDefault<T>() where T : IClosableWnd
        {
            var view = _container.Get<T>();
            return CreateDefault(view);
        }

        private void WndGotFocus(object sender, Avalonia.Input.GotFocusEventArgs e)
        {
            _current = (Window)sender;
        }

        public Window CreateDialog(IClosableWnd model)
        {

            return TaskHelper.RunSync(() =>
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    var wnd = new DefaultWindow
                    {
                        Width = 400,
                        Height = 200,
                        CanResize = false,
                        WindowState = model.SizeState,
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

        private void WndClosed(object sender, EventArgs e)
        {
            lock (_lock)
            {
                var wnd = (Window)sender;
                if (!_openedWindows.Remove(wnd))
                {
                    throw new Exception();//TODO need idea how to catch window, that creates not from IWindowService
                }
            }
        }

        public async Task SetupMainWindowView(IClosableWnd view)
        {
            if(Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    desktop.MainWindow.DataContext = view;
                    desktop.MainWindow.Content = _viewLocator.Build(view);
                });
            }
        }
    }
}
