namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Interface for accessing the server schema change history
    /// </summary>
    public interface ISchemaHistory : IBase
    {
        /// <summary>
        /// Retrieving a record of the history schema change by its index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns>History record object</returns>
        ISchemaHistoryItem this[int idx] { get; }
        /// <summary>
        /// Number of history records
        /// </summary>
        int Count { get; }
    }
}
