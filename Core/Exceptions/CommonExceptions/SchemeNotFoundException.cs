using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception rised when shceme (folder, fields, etc) not found for object
    /// </summary>
    [Serializable]
    public class SchemeNotFoundException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public SchemeNotFoundException(): base(Resource.SchemeNotFoundException,AppExceptionStatus.Terminate)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public SchemeNotFoundException(string message, Exception innerException): base(message, innerException, AppExceptionStatus.Terminate)
        {

        }
    }
}
