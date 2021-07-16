namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User messages collection
    /// </summary>
    public interface INotifiedMessages : IBase
    {
        /// <summary>
        /// Get message by index
        /// </summary>
        /// <param name="idx">0...Count-1 index value</param>
        /// <returns></returns>
        INotifiedMessage this[int idx] { get; }
        /// <summary>
        /// Message count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Read all messages
        /// </summary>
        void ReadAll();
        /// <summary>
        /// Clear all messages
        /// </summary>
        void Clear();
        /// <summary>
        /// Create new message
        /// </summary>
        INotifiedMessage Create(IUser sender, string message, ICustomObject linkedObject);
        /// <summary>
        /// Get new or unreaded messages
        /// </summary>
        /// <returns>Message collection</returns>
        INotifiedMessages GetNewMessages();
    }
}
