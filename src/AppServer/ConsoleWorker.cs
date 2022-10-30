using System;
using System.Threading;
using System.Threading.Tasks;

using FlexiObject.Core.Logging;

namespace FlexiObject.AppServer
{
    public class ConsoleWorker
    {
        private readonly ILogger _logger;
        public ConsoleWorker(LoggerFactory loggerFactory)
        {
            _logger = loggerFactory.Create<ConsoleWorker>();
        }

        public void Execute(CancellationToken stoppingToken, Action callExit)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        if (!Console.KeyAvailable)
                        {
                            Thread.Sleep(100);
                            continue;
                        }

                        var command = Console.ReadLine();
                        _logger.Info($"Worker running at: {DateTimeOffset.Now}, command: {command}");
                        if (command == "exit")
                        {
                            callExit();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex);
                }
            },stoppingToken);
        }
    }
}
