using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Notification message to user
    /// </summary>
    public interface INotifiedMessage : IBase
    {
        /// <summary>
        /// Message text
        /// </summary>
        string Message { get;}
        /// <summary>
        /// Custom object linked to message
        /// </summary>
        ICustomObject LinkedCustomObject {get;}
        /// <summary>
        /// Date time of message
        /// </summary>
        DateTime EventDate { get; }
        /// <summary>
        /// User-sender
        /// </summary>
        IUser Sender { get; }
        /// <summary>
        /// Is readed flag
        /// </summary>
        bool IsReaded { get; }
        /// <summary>
        /// Message readed date
        /// </summary>
        DateTime? ReadedDate { get; }
        /// <summary>
        /// Read message
        /// </summary>
        void Read();
        /// <summary>
        /// Remove message
        /// </summary>
        void Delete();
    }
}
