using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Index out of range exception in applications object collections
    /// </summary>
    [Serializable]
    public class CoaIndexOutOfRangeException : CoaApplicationException
    {
        /// <summary>
        /// Standard constructor with definiton type index out of range exception
        /// </summary>
        /// <param name="collectonType">Collection type string</param>
        public CoaIndexOutOfRangeException(string collectonType) : base(
            string.Format(Resource.CoaIndexOutOfRangeException_CollectionType, collectonType),
            AppExceptionStatus.Terminate)
        {
        }
        /// <summary>
        /// Constructor with definition type index out of range exception and additional exception object
        /// </summary>
        /// <param name="collectonType">Collection type string</param>
        /// <param name="innerException">Additional exception object</param>
        public CoaIndexOutOfRangeException(string collectonType, Exception innerException) : base(
            string.Format(Resource.CoaIndexOutOfRangeException_CollectionType, collectonType),
            innerException,
            AppExceptionStatus.Terminate)
        {
        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/innerException/*'/>
        public CoaIndexOutOfRangeException(Exception innerException) : base(Resource.CoaIndexOutOfRangeException, innerException, AppExceptionStatus.Terminate)
        {

        }
        /// <include file='exceptionDoc.xml' path='docs/members[@name="exception"]/default/*'/>
        public CoaIndexOutOfRangeException() : base(Resource.CoaIndexOutOfRangeException, AppExceptionStatus.Terminate)
        {
        }
    }
}
