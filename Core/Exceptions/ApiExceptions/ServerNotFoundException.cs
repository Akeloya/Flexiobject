using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions.ApiExceptions
{
    /// <summary>
    /// Exception for client side calling when not found server
    /// </summary>
    [Serializable]
    public class ServerNotFoundException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public ServerNotFoundException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public ServerNotFoundException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public ServerNotFoundException() : base(Resource.ServerNotFoundExceptionNoInfo, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Fully qualified exception constructor
        /// </summary>
        /// <param name="host">Host name</param>
        /// <param name="port">Port number</param>
        public ServerNotFoundException(string host, int port) : base(string.Format(Resource.ServerNotFoundException, host, port), AppExceptionStatus.Work)
        {

        }
    }
}
