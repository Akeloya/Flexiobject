using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Group syncronization exception throws when missing syncronization object linked with group
    /// </summary>
    [Serializable]
    public class GroupSyncRequestException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public GroupSyncRequestException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public GroupSyncRequestException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public GroupSyncRequestException() : base(Resource.GroupSyncRequestException, AppExceptionStatus.Work)
        {
        }
    }
}
