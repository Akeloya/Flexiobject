using Avalonia.Controls;
using FlexiObject.AppClient.Views;

using System;
using System.Collections.Generic;
using FlexiObject.Core.Config;
using FlexiObject.AppClient.Core;

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
                Height= model.Height,
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
    }
}
