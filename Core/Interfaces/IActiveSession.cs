using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Active (current) user session
    /// </summary>
    public interface IActiveSession : IBase
    {
        /// <summary>
        /// Client type
        /// </summary>
        string ClientType { get; }
        /// <summary>
        /// User host name
        /// </summary>
        string HostName { get; }
        /// <summary>
        /// User loged in time
        /// </summary>
        DateTime LoginTime { get; }
        /// <summary>
        /// Idle time (no traffic between client and server)
        /// </summary>
        DateTime IdleTime { get; }
        /// <summary>
        /// User name (login)
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Close session
        /// </summary>
        void Close();
    }
}