using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CoaGroupCollectionReadonlyException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaGroupCollectionReadonlyException() : base(Resource.CoaGroupCollectionReadonlyException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaGroupCollectionReadonlyException(Exception innerException) : 
            base(Resource.CoaGroupCollectionReadonlyException, 
                innerException, 
                AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaGroupCollectionReadonlyException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaGroupCollectionReadonlyException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
    }
}
