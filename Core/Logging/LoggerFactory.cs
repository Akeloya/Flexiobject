
using Microsoft.Extensions.Logging;

using System;

namespace CoaApp.Core.Logging
{
    public class LoggerFactory
    {
        private ILoggerFactory loggerFactory;
        public LoggerFactory()
        {
            loggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
        }
        public ILogger Create(string name)
        {
            return new Logger(loggerFactory.CreateLogger(name));
        }

        public ILogger Create<T>()
        {
            return new Logger(loggerFactory.CreateLogger<T>());
        }

        public ILogger Create(Type type)
        {
            return new Logger(loggerFactory.CreateLogger(type));
        }
    }
}
