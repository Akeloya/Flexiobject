namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// View layouts collection
    /// </summary>
    public interface IViewLayouts : IBase
    {
        /// <summary>
        /// Collection count
        /// </summary>
        int Count { get; set; }
        /// <summary>
        /// Access to view collection by index
        /// </summary>
        /// <param name="idx">0...Count-1 index value</param>
        /// <returns>IViewLayout object</returns>
        IViewLayout this[int idx] { get; }
    }
}