using FlexiObject.Core.Config;

using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Xml.Serialization;

namespace FlexiObject.Core.Transport
{
    public class ExchangeMessage
    {
        public Guid MessageID { get; set; } = Guid.NewGuid();
        public Guid ClientUid { get; set; }
        public string Method { get; set; }
        public int ThreadId { get; set; }
        public DateTime TimeSend { get; set; }
        public DateTime TimeRecieve { get; set; }
        public string Data { get; set; }
        public string ObjectType { get; set; }
        public object[] Parameters { get; set; }
        public Exception Error { get; set; }
        [JsonIgnore]
        public ManualResetEvent SyncObj { get; set; }
        public ExchangeMessage(ExchangeMessage msg)
        {
            ThreadId = msg.ThreadId;
            ClientUid = msg.ClientUid;
            Method = msg.Method;
            MessageID = msg.MessageID;
        }

        public ExchangeMessage()
        {

        }

        public object Deserialize(Type type)
        {
            return JsonSerializer.Deserialize(Data, type, DefaultJsonSerializerOptions.Value);
        }

        public T Deserialize<T>()
        {
            return JsonSerializer.Deserialize<T>(Data, DefaultJsonSerializerOptions.Value);
        }

        public void SerializeData(object data)
        {
            Data = JsonSerializer.Serialize(data, DefaultJsonSerializerOptions.Value);
        }

        public object DeserializeData(Type type)
        {
            return JsonSerializer.Deserialize(Data, type, DefaultJsonSerializerOptions.Value);
        }
    }

    public static class ExchangeMessageExt
    {
        /// <summary>
        /// Сериализация сообщения
        /// </summary>
        /// <param name="anySerializableObject">Сообщение</param>
        /// <returns>Двоичные данные для передачи</returns>
        public static string Serialize(this ExchangeMessage anySerializableObject)
        {
            var xmlSerializer = new XmlSerializer(typeof(ExchangeMessage));
            using var memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, anySerializableObject);
            var tr = new StreamReader(memoryStream);
            var str = tr.ReadToEnd();
            return JsonSerializer.Serialize(anySerializableObject, DefaultJsonSerializerOptions.Value);
        }
        /// <summary>
        /// Десереализация
        /// </summary>
        /// <param name="data">двоичные данные для десеариализации</param>
        /// <returns>Полученное сообщение</returns>
        public static ExchangeMessage Deserialize(this string data)
        {
            return JsonSerializer.Deserialize<ExchangeMessage>(data, DefaultJsonSerializerOptions.Value);
        }
    }
}
