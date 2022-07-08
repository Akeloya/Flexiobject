using NLog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoaApp.Core.Transport
{
    public static class TransportHelpers
    {
        public static Logger Logger = LogManager.GetCurrentClassLogger();
        public static bool ReadData(this NetworkStream stream, out ExchangeMessage data)
        {
            const int arrSize = 1024;
            if (!stream.DataAvailable)
            {
                data = null;
                return false;
            }

            try
            {
                var buffer = new byte[arrSize];
                var dataList = new LinkedList<byte[]>();
                var readedData = stream.Read(buffer, 0, arrSize);
                if(readedData == 0)
                {
                    data = null;
                    return false;
                }

                do
                {
                    if (readedData == 0)
                        break;
                    if (readedData != arrSize)
                        buffer = buffer.AsSpan(0, readedData).ToArray();
                    dataList.AddLast(buffer);
                    buffer = new byte[arrSize];
                    readedData = 0;
                    if(stream.DataAvailable)
                        readedData = stream.Read(buffer, 0, arrSize);
                } while (readedData > 0);

                var totalDataSize = dataList.Sum(p => p.Length);
                var dataArr = new byte[totalDataSize];
                int lastIndex = 0;
                foreach (var item in dataList)
                {
                    item.CopyTo(dataArr, lastIndex);
                    lastIndex += item.Length;
                }
                data = Encoding.UTF8.GetString(dataArr).Deserialize();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                data = null;
                return false;
            }
            return true;
        }

        public static async Task<ExchangeMessage> ReadDataAsync(this NetworkStream stream, CancellationToken token)
        {
            const int arrSize = 1024;
            if (!stream.DataAvailable)
                return null;

            try
            {
                var buffer = new byte[arrSize];
                var dataList = new LinkedList<byte[]>();
                var readedData = await stream.ReadAsync(buffer.AsMemory(0, arrSize), token);
                if (readedData == 0)
                    return null;
                do
                {
                    if (readedData == 0)
                        break;
                    if (readedData != arrSize)
                        buffer = buffer.AsSpan(0, readedData).ToArray();
                    dataList.AddLast(buffer);
                    buffer = new byte[arrSize];
                    readedData = 0;
                    if (stream.DataAvailable)
                        readedData = await stream.ReadAsync(buffer.AsMemory(0, arrSize), token);
                } while (readedData > 0 && !token.IsCancellationRequested);

                var totalDataSize = dataList.Sum(p => p.Length);
                var dataArr = new byte[totalDataSize];
                int lastIndex = 0;
                foreach (var item in dataList)
                {
                    item.CopyTo(dataArr, lastIndex);
                    lastIndex += item.Length;
                }
                return Encoding.UTF8.GetString(dataArr).Deserialize();
            }
            catch(Exception ex)
            {
                Logger.Error(ex);
                return null;
            }
        }
    }
}
