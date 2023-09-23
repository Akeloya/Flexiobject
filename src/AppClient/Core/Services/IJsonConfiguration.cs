using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Core.Services
{
    public interface IJsonConfiguration
    {
        public T LoadSettings<T>();
        public Task<T> LoadSettingsAsync<T>();
    }
}
