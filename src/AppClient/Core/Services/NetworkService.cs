using FlexiObject.Core.Logging;

using System;
using System.Timers;

namespace FlexiObject.AppClient.Core.Services
{
    /// <summary>
    /// Testing connection to application server/database
    /// </summary>
    internal class NetworkService : IDisposable
    {
        private readonly Timer _timer = new();
        private readonly ILogger _logger;
        public NetworkService(LoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create<NetworkService>();
            _timer.Elapsed += NetworkTestElapsed;
        }

        private void NetworkTestElapsed(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _logger.Trace("NetworkService started");
            _timer.Start();
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
