using FlexiObject.AppServer.Settings;

using System.Threading;
using EmbedIO.Actions;
using EmbedIO;
using FlexiObject.AppServer.Controllers;
using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using EmbedIO.WebApi;
using FlexiObject.Core.Config.SettingsStore;

namespace FlexiObject.AppServer.Model
{
    internal class Server
    {
        private readonly ILogger _logger;
        private readonly JsonSettingsStore _jsonSettingsStore;
        private ServerSettings _serverSettings;
        private WebServer _server;
        private readonly IContainer _container;
        public Server(JsonSettingsStore jsonSettingsStore, LoggerFactory loggerFactory, IContainer container)
        {
            _jsonSettingsStore = jsonSettingsStore;
            _logger = loggerFactory.Create(nameof(Server));
            _container = container;
        }

        public void Start(CancellationToken cts)
        {
            _serverSettings = _jsonSettingsStore.Load<ServerSettings>();
            _server = CreateWebServer($"http://{_serverSettings.HostName ?? "localhost"}:{_serverSettings.Port}/");
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
                    .WithController(()=> _container.Get<AppController>()))
                .WithWebApi("/", m=> m
                    .WithController(()=> _container.Get<DefaultController>()))
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
