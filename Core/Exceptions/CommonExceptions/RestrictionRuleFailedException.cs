using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Exception for link rule check
    /// </summary>
    [Serializable]
    public class RestrictionRuleFailedException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public RestrictionRuleFailedException() : base(Resource.RestrictionRuleFailedException, AppExceptionStatus.Work)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public RestrictionRuleFailedException(Exception innerException) : base(Resource.RestrictionRuleFailedException, innerException, AppExceptionStatus.Work)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public RestrictionRuleFailedException(string message) : base(message, AppExceptionStatus.Work)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public RestrictionRuleFailedException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Work)
        {
        }
    }
}
