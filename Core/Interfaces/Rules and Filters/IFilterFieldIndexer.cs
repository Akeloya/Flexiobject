namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Interface to acces rule indexer
    /// </summary>
    public interface IFilterFieldIndexer
    {
        /// <summary>
        /// Access by field name
        /// </summary>
        /// <param name="name">Field name</param>
        /// <returns>Field or value for this field</returns>
        object this[string name] { get; set; }
    }
}