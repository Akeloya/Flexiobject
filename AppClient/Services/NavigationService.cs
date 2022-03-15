using Avalonia.Controls;

using FlexiObject.AppClient.ViewModels;

using System;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public Task NavigateAsync(Type type, params object[] args)
        {
            throw new NotImplementedException();
        }

        private Window CreateWindow(ViewModelBase view)
        {
            var wnd = _windowService.CreateDefault(view);                        
            wnd.DataContext = view;
            return wnd;
        }
    }
}
