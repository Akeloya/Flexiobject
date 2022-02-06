using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Common exceptions for Application folder errors
    /// </summary>
    [Serializable]
    public class CoaAppFolderException : CoaApplicationException
    {
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/message/*'/>
        public CoaAppFolderException(string message) : base(message, AppExceptionStatus.Terminate)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/messageInnerException/*'/>
        public CoaAppFolderException(string message, Exception innerException) : base(message, innerException, AppExceptionStatus.Terminate)
        {
        }

    }
}
