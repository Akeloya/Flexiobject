using Microsoft.Extensions.Configuration;

using System;
using System.IO;
using System.Threading.Tasks;

namespace FlexiObject.AppClient.Services
{
    public class JsonConfiguration : IJsonConfiguration
    {
        private IConfiguration _configuration;
        private const string _jsonFileName = "appsettings.json";
        public JsonConfiguration()
        {
            
        }
        public T LoadSettings<T>()
        {
            BuildConfiguration();
            var section = _configuration.GetSection(nameof(T));
            return section.Get<T>();
        }

        public Task<T> LoadSettingsAsync<T>()
        {
            return Task<T>.Factory.StartNew(() => {  return LoadSettings<T>(); });
        }

        private void BuildConfiguration()
        {
            if (_configuration != null)
                return;
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _jsonFileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(_jsonFileName).Build();
        }
    }
}
