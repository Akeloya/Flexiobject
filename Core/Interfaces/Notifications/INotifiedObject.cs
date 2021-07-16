namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Notification interface
    /// </summary>
    public interface INotifiedObject : IBase
    {
        /// <summary>
        /// Notify user with message
        /// </summary>
        /// <param name="message">String message text</param>
        /// <param name="linkedObject">Linked object to message</param>
        void Notify(string message, object linkedObject);
        /// <summary>
        /// Message collection
        /// </summary>
        /// <returns><seealso cref="INotifiedMessages"/>Message collection object</returns>
        INotifiedMessages Messages { get; }
    }
}
