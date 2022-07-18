using System;

namespace CoaApp.Core.Logging
{
    public interface ILogger
    {
        void Info(string msg);
        void Warn(string msg);
        void Error(Exception ex, string msg = null);
        void Debug(string msg);
        void Trace(string msg);
    }

    public class Logger : ILogger
    {
        private readonly NLog.ILogger _logger;
        internal Logger(NLog.ILogger logger)
        {
            _logger = logger;
        }
        public void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public void Error(Exception ex, string msg = null)
        {
            _logger.Error(msg, ex, null);
        }

        public void Info(string msg)
        {
            _logger.Info(msg);
        }

        public void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public void Trace(string msg)
        {
            _logger.Trace(msg);
        }
    }
}
