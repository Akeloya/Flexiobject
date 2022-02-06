using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception thowns when saving CoaUser object without password, but it must be
    /// </summary>
    [Serializable]
    public class CoaUserPasswordRequiredException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaUserPasswordRequiredException() : base(Resource.CoaUserPasswordRequiredException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaUserPasswordRequiredException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaUserPasswordRequiredException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaUserPasswordRequiredException(Exception innerException) : base(Resource.CoaUserPasswordRequiredException, innerException, AppExceptionStatus.Work)
        {

        }
    }
}
