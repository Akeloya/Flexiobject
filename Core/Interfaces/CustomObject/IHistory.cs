namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// History modification of object
    /// </summary>
    public interface IHistory : IBase
    {
        /// <summary>
        /// History record count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access to history record by index
        /// </summary>
        /// <param name="idx">0...Count-1 value of index</param>
        /// <returns></returns>
        IHistoryRecord this[int idx] { get; }        
    }
}