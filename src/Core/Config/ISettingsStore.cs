using System.Threading.Tasks;

namespace FlexiObject.Core.Config
{
    public interface ISettingsStore
    {
        T Load<T>();
        Task<T> LoadAsync<T>();
        void Save<T>(T settings);
        Task SaveAsync<T>(T settings);
    }
}
