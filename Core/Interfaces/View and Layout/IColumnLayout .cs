using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Column data layout
    /// </summary>
    public interface IColumnLayout : IBase
    {
        /// <summary>
        /// Column count in layout
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Adding new column to layout
        /// </summary>
        /// <param name="type">Column type (how it will be displaing)</param>
        /// <param name="field">Field path</param>
        /// <param name="width">Visual width</param>
        /// <param name="header">Visual label</param>
        void AddColumn(CoaColumnType type, string field, int width, string header);
        /// <summary>
        /// Get field path
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        string GetColumnField(int index);
        /// <summary>
        /// Get column header by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        string GetColumnHeaderName(int index);
        /// <summary>
        /// Get column type by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        CoaColumnType GetColumnType(int index);
        /// <summary>
        /// Get column width by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        int GetColumnWidth(int index);
        /// <summary>
        /// Remove column by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        void RemoveColumn(int index);

    }
}