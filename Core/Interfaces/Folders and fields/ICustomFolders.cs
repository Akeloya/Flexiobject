namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Custom folder collection
    /// </summary>
    public interface ICustomFolders : IBase
    {
        /// <summary>
        /// Acces to collection by index
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ICustomFolder/null</returns>
        ICustomFolder this[int id] { get; }
        /// <summary>
        /// Access to folder in collection by alias
        /// </summary>
        /// <param name="alias">Folder alias</param>
        /// <returns>ICustomFolder/null</returns>
        ICustomFolder this[string alias] { get; }
        /// <summary>
        /// Folder count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Add new folder
        /// </summary>
        /// <param name="name">Folder name</param>
        /// <param name="alias">Folder alias</param>
        /// <param name="parentFolder">Parent folder</param>
        /// <returns></returns>
        ICustomFolder Add(string name, string alias, ICustomFolder parentFolder);
        /// <summary>
        /// Remove folder
        /// </summary>
        /// <param name="id">Removing folder id</param>
        /// <param name="force">Ignore existing objects</param>
        void Remove(int id, bool force = false);
        /// <summary>
        /// Remove folder
        /// </summary>
        /// <param name="folder">Folder object to remove</param>
        /// <param name="force">Ignore existing objects</param>
        void Remove(ICustomFolder folder, bool force = false);
    }
}