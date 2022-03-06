using Avalonia.Controls;

using System;
using System.Threading.Tasks;

namespace AppClient.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IContainer _container;
        public NavigationService(IContainer container)
        {
            _container = container;
        }
        public void Navigate<T>(params object[] args)
        {
            CreateWindow(_container.Get<T>()).Show();
        }

        public void Navigate(Type type, params object[] args)
        {
            CreateWindow(_container.Get(type)).Show();
        }

        public Task NavigateAsync<T>(params object[] args)
        {
            throw new NotImplementedException();
        }

        public Task NavigateAsync(Type type, params object[] args)
        {
            throw new NotImplementedException();
        }

        private Window CreateWindow(object view)
        {
            var locator = new ViewLocator();
            return new Window
            {
                Content = locator.Build(view),
                DataContext = view,
            };
        }
    }
}
