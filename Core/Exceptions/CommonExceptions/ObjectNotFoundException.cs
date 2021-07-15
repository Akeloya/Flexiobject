using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Calling exception when object not found in database
    /// </summary>
    [Serializable]
    public class ObjectNotFoundException : CoaApplicationException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="objectId">UniqueId of object</param>
        public ObjectNotFoundException(long objectId) : base(string.Format(Resource.CoaObjectNotFoundException, objectId), AppExceptionStatus.Work)
        {

        }
        /// <summary>
        /// Constructor for exception with inner exception
        /// </summary>
        /// <param name="objectId">UniqueId of object</param>
        /// <param name="inner">Inner exception</param>
        public ObjectNotFoundException(long objectId, Exception inner) : base (string.Format(Resource.CoaObjectNotFoundException, objectId), inner, AppExceptionStatus.Work)
        {

        }
    }
}
