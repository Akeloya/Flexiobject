namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Script history access interface
    /// </summary>
    public interface IScriptHistoryItems : IBase
    {
        /// <summary>
        /// Access to history record
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns>History record</returns>
        IScriptHistoryItem this[int index] { get; }        
        /// <summary>
        /// History items count
        /// </summary>
        int Count { get; }
    }
}
