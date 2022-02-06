using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Environment definition of application
    /// </summary>
    public abstract class CoaInvironment
    {
#pragma warning disable IDE0032
        private static string _serverVersion;
        private static string _clientVersion;
        private static CoaApplication _application;
        [ThreadStatic] private static CoaSession _session;
#pragma warning restore IDE0032
        internal static string ServerVersion => _serverVersion;
        internal static string ClientVersion => _clientVersion;
        internal static CoaApplication Application => _application;
        /// <summary>
        /// Definition of base constructor
        /// </summary>
        protected CoaInvironment(string serverVersion, string clientVersion, CoaApplication app)
        {
            _serverVersion = serverVersion;
            _clientVersion = clientVersion;
            _application = app;
        }
        /// <summary>
        /// Update session info
        /// </summary>
        /// <param name="session">ThreadStatic session data</param>
        protected virtual void SetSession(CoaSession session)
        {
            _session = session;
        }
    }
}
