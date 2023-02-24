namespace FlexiObject.Core.Interfaces
{
    public interface IApplication
    {
        /// <summary>
        /// Write string message to write in server log
        /// </summary>
        /// <param name="msg">Message text</param>
        void WriteLogMessage(string msg);
        /// <summary>
        /// Open new session to server
        /// </summary>
        /// <param name="hostName">Server host name</param>
        /// <param name="port">Server port</param>
        /// <param name="userName">Application user name</param>
        /// <param name="password">Application user password</param>
        /// <returns>Session object</returns>
        ISession OpenSession(string hostName, int port, string userName = null, string password = null);
    }
}
