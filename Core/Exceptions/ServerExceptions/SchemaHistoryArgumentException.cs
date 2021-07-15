using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Scheme history argument exception
    /// </summary>
    [Serializable]
    public class SchemaHistoryArgumentException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public SchemaHistoryArgumentException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public SchemaHistoryArgumentException() : base(Resource.SchemaHistoryArgumentException, AppExceptionStatus.Work)
        {
        }
        /// <summary>
        /// Schema history exception with argument name
        /// </summary>
        /// <param name="argumentName">Name of invalid argument</param>
        public SchemaHistoryArgumentException(string argumentName) : base(string.Format(Resource.SchemaHistoryArgumentExceptionWithArgName, argumentName), AppExceptionStatus.Work)
        {

        }
    }
}
