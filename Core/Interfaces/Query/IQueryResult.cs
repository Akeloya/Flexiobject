namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Query results
    /// </summary>
    public interface IQueryResult : IBase
    {
        /// <summary>
        /// Column count
        /// </summary>
        int ColumnCount { get; }
        /// <summary>
        /// Access query column by index
        /// </summary>
        /// <param name="index">0..ColumnCount-1 index value</param>
        /// <returns></returns>
        IQueryResultColumn this[int index] { get; }
        /// <summary>
        /// Rows count
        /// </summary>
        int Rows { get; }
        /// <summary>
        /// Data value
        /// </summary>
        /// <param name="row">0..Rows index value</param>
        /// <param name="col">0..ColumnCount index value</param>
        /// <returns></returns>
        object this[int row, int col] { get; }
    }
}