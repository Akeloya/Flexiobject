using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception rised in unexpected modification of application group
    /// </summary>
    [Serializable]
    public class CoaGroupModificationException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaGroupModificationException(): base(Resource.CoaGroupModificationException, AppExceptionStatus.Work)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaGroupModificationException(Exception innerException) : base(Resource.CoaGroupModificationException, innerException, AppExceptionStatus.Work)
        {

        }
    }
}
