using FlexiObject.Core.Transport;
using FlexiObject.Core.Transport.DataContracts;

using NLog;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FlexiObject.API.Transport
{
    /// <summary>
    /// Клиентская реализация общения с сервером.
    /// Отправляем сообщение и засыпаем до наступления таймаута.
    /// В бэкграунде поток ловит сообщения от сервера. Если сообщение есть в куче - обновляет его и вызывает синхронизацию с заснувшим потоком,
    /// чтобы он забрал сообщение из кучи и отдал ответ.
    /// </summary>
    class Client : IDisposable
    {
        private readonly Guid _clientUid = Guid.NewGuid();
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        internal static ClientFactory Factory { get; }
        static Client()
        {
            Factory = new ClientFactory();
        }
        public Client()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _httpClient = new HttpClient();
        }
        public async Task Open(string hostName, int port)
        {
            _httpClient.BaseAddress = new Uri($"http://{hostName}:{port}");
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
            _logger.Trace($"Creating client to {hostName}:{port}");

            var result = await GetDataAsync<PingDataContract>("/ping", new CancellationTokenSource(TimeSpan.FromSeconds(60)).Token);
            _logger.Info($"Server info. Version: {result.Version}, Time: {result.DateTime}, Info: {result.ServerInfo}");
        }
        public async Task<T> GetDataAsync<T>(string requestUri, CancellationToken token)
        {
            var result = await _httpClient.GetAsync(requestUri, token);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostDataAsync<T>(string requestUri, object data, CancellationToken token)
        {
            var jsonContent = JsonContent.Create(data, data.GetType());
            var result = await _httpClient.PostAsync(requestUri, jsonContent, token);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> DeleteDataAsync<T>(string requestUri, CancellationToken token)
        {
            var result = await _httpClient.DeleteAsync(requestUri, token);
            result.EnsureSuccessStatusCode();
            return await result.Content.ReadFromJsonAsync<T>();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
