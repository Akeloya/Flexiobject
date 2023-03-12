using Avalonia.Controls;

using System;
using System.Threading.Tasks;
using FlexiObject.Core.Config;
using FlexiObject.AppClient.Core;

namespace FlexiObject.AppClient.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IWindowService _windowService;
        private readonly IContainer _container;

        public NavigationService(IWindowService windowService, IContainer container)
        {
            _windowService = windowService;
            _container = container;
        }
        public void Navigate<T>(params object[] args)
        {
            CreateWindow(_container.Get<T>() as ViewModelBase).Show();
        }

        public void Navigate(Type type, params object[] args)
        {
            CreateWindow(_container.Get(type) as ViewModelBase).Show();
        }

        public Task NavigateAsync<T>(params object[] args)
        {
            return Task.Factory.StartNew(() => Navigate<T>(args));
        }

        public Task NavigateAsync(Type type, params object[] args)
        {
            return Task.Factory.StartNew(() => Navigate(type, args));
        }

        private Window CreateWindow(ViewModelBase view)
        {
            var wnd = _windowService.CreateDefault(view);                        
            wnd.DataContext = view;
            return wnd;
        }
    }
}
