using NLog;

using System;

namespace FlexiObject.Core.Logging
{
    public class LoggerFactory
    {
        private LogFactory loggerFactory;
        public LoggerFactory()
        {
            loggerFactory = LogManager.LogFactory;
        }
        public ILogger Create(string name)
        {
            return new Logger(loggerFactory.GetLogger(name));
        }

        public ILogger Create<T>()
        {
            return new Logger(loggerFactory.GetLogger(typeof(T).Name));
        }

        public ILogger Create(Type type)
        {
            return new Logger(loggerFactory.GetLogger(type.Name));
        }
    }
}
