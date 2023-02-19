using FlexiObject.Core;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Logging;

using System;

namespace FlexiObject.AppServer.Model
{
    internal class CoaSession : Session
    {
        private ILogger _logger;
        public CoaSession(Application app, LoggerFactory loggerFactory) : base(app)
        {
            _logger = loggerFactory.Create<ISession>();
        }

        public override IActiveSessions ActiveSessions => throw new NotImplementedException();

        public override void LogMessage(string msg)
        {
            _logger.Info(msg);
        }

        public override void Logoff()
        {
            throw new NotImplementedException();
        }
    }
}
