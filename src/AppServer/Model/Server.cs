using FlexiObject.AppServer.Settings;

using System.Threading;
using EmbedIO.Actions;
using EmbedIO;
using FlexiObject.AppServer.Controllers;
using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using EmbedIO.WebApi;

namespace FlexiObject.AppServer.Model
{
    internal class Server
    {
        private readonly ILogger _logger;
        private readonly JsonSettingsStore _jsonSettingsStore;
        private ServerSettings _serverSettings;
        private WebServer _server;
        private CancellationTokenSource _cts = new();
        public Server(JsonSettingsStore jsonSettingsStore, LoggerFactory loggerFactory)
        {
            _jsonSettingsStore = jsonSettingsStore;
            _logger = loggerFactory.Create(nameof(Server));
        }

        public void Start(CancellationToken cts)
        {
            _server = CreateWebServer("http://localhost:9696/");
            _server.Start(cts);
        }

        // Create and configure our web server.
        private WebServer CreateWebServer(string url)
        {
            var server = new WebServer(o => o
                    .WithUrlPrefix(url)
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithLocalSessionManager()
                .WithWebApi("/api", m => m
                    .WithController<AppController>())
                .WithWebApi("/", m=> m
                    .WithController<DefaultController>())
                .WithModule(new WebSocketsSessionModule("/session"))
                .WithModule(new ActionModule("/", HttpVerbs.Any, ctx => ctx.SendDataAsync(new { Message = "Error" })));

            server.StateChanged += LogState;

            return server;
        }

        private void LogState(object s, WebServerStateChangedEventArgs e)
        {
            _logger.Trace($"WebServer New State - {e.NewState}");
        }
    }
}
