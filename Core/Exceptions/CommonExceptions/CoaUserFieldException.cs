using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions.CommonExceptions
{
    /// <summary>
    /// Exception rised in user field
    /// </summary>
    [Serializable]
    public class CoaUserFieldException: CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaUserFieldException() : base(Resource.CoaUserFieldException, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaUserFieldException(string message) : base(message, AppExceptionStatus.Work)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaUserFieldException(Exception innerException) : base(Resource.CoaUserFieldException,innerException, AppExceptionStatus.Work)
        {

        }
    }
}
