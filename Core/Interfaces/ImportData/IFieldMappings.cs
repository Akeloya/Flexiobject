namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field mapping collection
    /// </summary>
    public interface IFieldMappings : IBase
    {
        /// <summary>
        /// Access to collection item by index
        /// </summary>
        /// <param name="idx">0...Count-1 index value</param>
        /// <returns>IFieldMapping object</returns>
        IFieldMapping this[int idx] { get; }
        /// <summary>
        /// Access to collection item by alias
        /// </summary>
        /// <param name="source">IFieldMapping alias</param>
        /// <returns></returns>
        IFieldMapping this[string source] { get; }
        /// <summary>
        /// Collection item count
        /// </summary>
        int Count { get; }
    }
}