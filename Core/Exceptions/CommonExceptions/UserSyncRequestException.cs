using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// User syncronization exception throws when missing syncronization object linked with user
    /// </summary>
    [Serializable]
    public class UserSyncRequestException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public UserSyncRequestException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public UserSyncRequestException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public UserSyncRequestException() : base(Resource.UserSyncRequestException, AppExceptionStatus.Work)
        {
        }
    }
}
