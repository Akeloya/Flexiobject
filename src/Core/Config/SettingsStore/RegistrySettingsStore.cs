using System;
using System.Threading.Tasks;

namespace FlexiObject.Core.Config.SettingsStore
{
    /// <inheritdoc/>
    internal class RegistrySettingsStore : IRegistrySettingsStore
    {
        public T Load<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> LoadAsync<T>()
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T settings)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync<T>(T settings)
        {
            throw new NotImplementedException();
        }
    }
}
