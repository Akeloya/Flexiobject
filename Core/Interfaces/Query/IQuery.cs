namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Data query
    /// </summary>
    public interface IQuery : IBase
    {
        /// <summary>
        /// Filter data by distinct 
        /// </summary>
        bool Distinct { get; set; }
        /// <summary>
        /// Filer objects
        /// </summary>
        IFilter Filter { get; set; }
        /// <summary>
        /// Add query column to select data
        /// </summary>
        /// <param name="name">Column name</param>
        /// <returns></returns>
        IQueryResultColumn AddColumn(string name);
        /// <summary>
        /// Group by field
        /// </summary>
        /// <param name="field"></param>
        void AddGroupField(object field);
        /// <summary>
        /// Add sort field
        /// </summary>
        /// <param name="field">Field to sort</param>
        /// <param name="descending">Ascending (default)/descending</param>
        void AddSortField(object field, bool descending = false);
        /// <summary>
        /// Execute query
        /// </summary>
        /// <returns>Query results</returns>
        IQueryResult Execute();

    }
}
