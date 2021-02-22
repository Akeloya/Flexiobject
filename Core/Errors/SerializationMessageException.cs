using CoaApp.Core.Properties;
using System;

namespace CoaApp.Core.Errors
{
    [Serializable]
    public class SerializationMessageException : AppException
    {

        public SerializationMessageException(Exception ex) : base(Resource.SerializationMessageException, ex)
        {
            
        }
    }
}
