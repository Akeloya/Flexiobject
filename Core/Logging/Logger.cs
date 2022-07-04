using System;

using Microsoft.Extensions.Logging;

namespace CoaApp.Core.Logging
{
    public interface ILogger
    {
        void Info(string msg);
        void Warn(string msg);
        void Error(Exception ex, string msg = null);
        void Debug(string msg);
    }

    public class Logger : ILogger
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        internal Logger(Microsoft.Extensions.Logging.ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string msg)
        {
            _logger.LogInformation(msg);
        }

        public void Error(Exception ex, string msg = null)
        {
            _logger.LogError(msg, ex);
        }

        public void Info(string msg)
        {
            _logger.LogInformation(msg);
        }

        public void Warn(string msg)
        {
            _logger.LogWarning(msg);
        }

        public void Trace(string msg)
        {
            _logger.LogTrace(msg);
        }
    }
}
