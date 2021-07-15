using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception rising when setting null in workflow field as value
    /// </summary>
    [Serializable]
    public class WorkflowNullValueException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public WorkflowNullValueException() : base(Resource.WorkflowNullValueException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public WorkflowNullValueException(Exception innerException) : base(Resource.WorkflowNullValueException, innerException, AppExceptionStatus.Work)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public WorkflowNullValueException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public WorkflowNullValueException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
    }
}
