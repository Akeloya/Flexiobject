using System;
using System.Threading.Tasks;

namespace AppClient.Services
{
    public interface INavigationService
    {
        public void Navigate<T>(params object[] args);
        public void Navigate(Type type, params object[] args);
        public Task NavigateAsync<T>(params object[] args);
        public Task NavigateAsync(Type type, params object[] args);
    }
}
