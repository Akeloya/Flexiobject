using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception rise during saving workflow field definition
    /// </summary>
    [Serializable]
    public class MissingStatusOnServerException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public MissingStatusOnServerException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public MissingStatusOnServerException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public MissingStatusOnServerException() : base(Resource.MissingStatusOnServerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public MissingStatusOnServerException(Exception innerException) : base(Resource.MissingStatusOnServerException, innerException, AppExceptionStatus.Work)
        { 
        }
    }
}
