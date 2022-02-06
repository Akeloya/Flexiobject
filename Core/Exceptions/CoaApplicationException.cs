using System;
using System.Runtime.Serialization;

namespace CoaApp.Core.Exceptions
{
    /// <summary>
    /// Base application serializable exception
    /// </summary>
    [Serializable]
    public abstract class CoaApplicationException : Exception
    {
        /// <summary>
        /// Application status
        /// </summary>
        public AppExceptionStatus Status { get; } = AppExceptionStatus.Terminate;
        /// <summary>
        /// Client version
        /// </summary>
        public string ClientVersion { get; } = CoaInvironment.ClientVersion;
        /// <summary>
        /// Server version
        /// </summary>
        public string ServerVersion { get; } = CoaInvironment.ServerVersion;
        /// <summary>
        /// Exception time occured
        /// </summary>
        public DateTime Occured { get; } = DateTime.Now;
        /// <summary>
        /// Default constructor
        /// </summary>
        public CoaApplicationException()
        {
        }
        /// <summary>
        /// Init new exception with message and status
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="status">Session status</param>
        public CoaApplicationException(string message, AppExceptionStatus status) : base(message)
        {
            Status = status;
        }
        /// <summary>
        /// Init new exception with message inner exception and app status
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="inner">Inner exception data</param>
        /// <param name="status">Session status</param>
        public CoaApplicationException(string message, Exception inner, AppExceptionStatus status) : base(message, inner)
        {
            Status = status;
        }

        /// <summary>
        /// Get data for deserialization exception
        /// </summary>
        /// <param name="info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected CoaApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Occured = info.GetDateTime(nameof(Occured));
            Status = (AppExceptionStatus)info.GetValue(nameof(Status), typeof(AppExceptionStatus));
            string serverVersion = info.GetString(nameof(ServerVersion));
            if (!string.IsNullOrEmpty(serverVersion))
                ServerVersion = serverVersion;
            string clientVersion = info.GetString(nameof(ClientVersion));
            if (!string.IsNullOrEmpty(clientVersion))
                ClientVersion = clientVersion;
        }
        /// <summary>
        /// Override GetObjectData to store additional information in exception
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(Status), Status);
            info.AddValue(nameof(Occured), Occured);
            info.AddValue(nameof(ClientVersion), ClientVersion);
            info.AddValue(nameof(ServerVersion), ServerVersion);
        }
    }

    /// <summary>
    /// Application status during exeption
    /// </summary>
    public enum AppExceptionStatus
    {
        /// <summary>
        /// Terminate application
        /// </summary>
        Terminate = 1,
        /// <summary>
        /// Allow work
        /// </summary>
        Work = 2
    }
}
