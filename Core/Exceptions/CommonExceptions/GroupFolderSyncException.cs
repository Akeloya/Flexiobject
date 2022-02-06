using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception throwns when user folder and app folder has breked link or link is missing
    /// </summary>
    [Serializable]
    public class GroupFolderSyncException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public GroupFolderSyncException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public GroupFolderSyncException(Exception innerException) : base(Resource.GroupSyncRequestException, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public GroupFolderSyncException() : base(Resource.GroupFolderSyncException, AppExceptionStatus.Work)
        {
        }
    }
}
