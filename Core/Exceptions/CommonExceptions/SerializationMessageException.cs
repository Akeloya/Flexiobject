using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception for definition problems with serialization data between server and client API
    /// </summary>
    [Serializable]
    public class SerializationMessageException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public SerializationMessageException(string message) : base(message, AppExceptionStatus.Terminate)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public SerializationMessageException(Exception innerException) : base(Resource.SerializationMessageException, innerException, AppExceptionStatus.Terminate)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public SerializationMessageException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Terminate)
        {
        }
    }
}
