namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Import data definition collection
    /// </summary>
    public interface IImportDefinitions : IBase
    {
        /// <summary>
        /// Definition object count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access to import definition by index
        /// </summary>
        /// <param name="idx">0...Count-1 index value</param>
        /// <returns></returns>
        IImportDefinition this[int idx] { get; }
        /// <summary>
        /// Access to import definition by name
        /// </summary>
        /// <param name="name">Definition name</param>
        /// <returns></returns>
        IImportDefinition this[string name] { get; }
        /// <summary>
        /// Add definition to user folder
        /// </summary>
        /// <param name="folder">The folder for which the data import setting is added</param>
        /// <returns></returns>
        IImportDefinition Add(ICustomFolder folder);
        /// <summary>
        /// Remove definition
        /// </summary>
        /// <param name="variant"></param>
        void Remove(object variant);
    }
}