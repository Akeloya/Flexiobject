using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Object not belong to collection exception
    /// </summary>
    [Serializable]
    public class CoaObjectNotBelontToCollectionException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaObjectNotBelontToCollectionException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaObjectNotBelontToCollectionException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaObjectNotBelontToCollectionException() : base(Resource.CoaObjectNotBelontToCollectionException, AppExceptionStatus.Work)
        {
        }
    }
}
