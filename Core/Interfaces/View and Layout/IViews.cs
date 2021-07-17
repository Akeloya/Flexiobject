namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// View collection
    /// </summary>
    public interface IViews : IBase
    {
        /// <summary>
        /// Get view by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns>IView object</returns>
        IView this[int idx] { get; }
        /// <summary>
        /// Items count
        /// </summary>
        int Count { get; }
    }
}
