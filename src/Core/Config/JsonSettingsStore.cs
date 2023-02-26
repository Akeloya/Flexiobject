using NLog;

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlexiObject.Core.Config
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class JsonSettingSubFolderAttribute : Attribute
    {
        public string FolderName { get; set; }
        public JsonSettingSubFolderAttribute(string folderName)
        {
            FolderName = folderName;
        }
    }

    public class JsonSettingsStore : IJsonSettingsStore
    {
        public T Load<T>()
        {
            var type = typeof(T);
            var path = GetSettingsFolderPath(type);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, GetFileName(type));
            T result = (T)Activator.CreateInstance(type);
            if (!File.Exists(path))
            {
                Save(result);
                return result;
            }
            var text = File.ReadAllText(path);
            try
            {
                result = JsonSerializer.Deserialize<T>(text, DefaultJsonSerializerOptions.Value);
                if (result == null)
                {
                    File.Delete(path);
                    result = (T)Activator.CreateInstance(type);
                    Save(result);
                }
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex);
                try
                {
                    Save(result);
                }
                catch (Exception ex2)
                {
                    logger.Error(ex2);
                }
            }
            return result;
        }

        public Task<T> LoadAsync<T>()
        {
            return Task.Factory.StartNew(() => Load<T>());
        }

        public void Save<T>(T settings)
        {
            var path = GetSettingsFolderPath(typeof(T));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var content = JsonSerializer.Serialize(settings, DefaultJsonSerializerOptions.Value);
            File.WriteAllText(Path.Combine(path, GetFileName(typeof(T))), content, Encoding.UTF8);
        }

        public Task SaveAsync<T>(T settings)
        {
            return Task.Factory.StartNew(() => Save<T>(settings));
        }

        private static string GetFileName(Type type)
        {
            string jsonFileName = type.Name;
            if (!jsonFileName.EndsWith(".json"))
                jsonFileName += ".json";
            return jsonFileName;
        }

        private static string GetSettingsFolderPath(Type type)
        {
            string path = PathConfigs.GetCommongDataDirectory();
            Attribute[] attrs = Attribute.GetCustomAttributes(type);
            foreach (var attr in attrs)
            {
                if (attr is JsonSettingSubFolderAttribute attribute)
                {
                    path = Path.Combine(path, attribute.FolderName);
                }
            }
            return path;
        }
    }
}
