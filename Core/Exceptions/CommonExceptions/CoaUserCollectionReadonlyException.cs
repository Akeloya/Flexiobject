using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CoaUserCollectionReadonlyException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaUserCollectionReadonlyException() : base(Resource.CoaUserCollectionReadonlyException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaUserCollectionReadonlyException(Exception innerException) : base(Resource.CoaUserCollectionReadonlyException, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaUserCollectionReadonlyException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaUserCollectionReadonlyException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
    }
}
