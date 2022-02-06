namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Basic application interface
    /// </summary>
    public interface IBase
    {
        /// <summary>
        /// Current application reference
        /// </summary>
        IApplication Application { get; }
        /// <summary>
        /// Reference to parent object or object-creator
        /// </summary>
        object Parent { get; }
    }
}
