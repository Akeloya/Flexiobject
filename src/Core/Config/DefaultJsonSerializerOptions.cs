using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlexiObject.Core.Config
{
    internal class DefaultJsonSerializerOptions
    {
        public static JsonSerializerOptions Value => new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, false)
            }
        };
    }
}
