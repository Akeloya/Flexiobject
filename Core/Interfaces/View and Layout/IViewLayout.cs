using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// View layout for object in folder (column, tree)
    /// </summary>
    public interface IViewLayout : IBase
    {
        /// <summary>
        /// Folder where will be displaing view
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// View laoyut name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// View type
        /// </summary>
        CoaViewTypes Type { get; set; }
        /// <summary>
        /// Add column laout to folder layout
        /// </summary>
        /// <param name="column">Column laoyut</param>
        void AddColumnLayout(IColumnLayout column);
        /// <summary>
        /// Add to folder view laoyt tree layout
        /// </summary>
        /// <param name="tree">Tree layout</param>
        void AddTreeLayout(ITreeLayout tree);
        /// <summary>
        /// Get column layout by folder Id
        /// </summary>
        /// <param name="folderId">Folder id</param>
        /// <returns></returns>
        IColumnLayout GetColumnLayout(int folderId);
        /// <summary>
        /// Get tree layout by folder id
        /// </summary>
        /// <param name="folderId">Folder id</param>
        /// <returns></returns>
        ITreeLayout GetTreeLayout(int folderId);        
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}