using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CoaApp.Core
{
    /// <summary>
    /// Serialization/Deserialization app message extension
    /// </summary>
    public static class ExchangeMessageExt
    {
        /// <summary>
        /// Сериализация сообщения
        /// </summary>
        /// <param name="msg">Message</param>
        /// <returns>Binary data to transmit</returns>
        public static byte[] Serialize(this ExchangeMessage msg)
        {
            using (var memoryStream = new MemoryStream())
            {
                (new BinaryFormatter()).Serialize(memoryStream, msg);
                return memoryStream.ToArray();
            }
        }
        /// <summary>
        /// Deserialization data
        /// </summary>
        /// <param name="data">Binary input data</param>
        /// <returns>App message</returns>
        public static ExchangeMessage Deserialize(this byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
                return (ExchangeMessage)(new BinaryFormatter()).Deserialize(memoryStream);
        }
    }
}
