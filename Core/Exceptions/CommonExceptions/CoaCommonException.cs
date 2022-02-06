using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception class for common error in app, see inner exception
    /// </summary>
    [Serializable]
    public class CoaCommonException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaCommonException(string message) : base(message, AppExceptionStatus.Terminate)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaCommonException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Terminate)
        {
        }
    }
}
