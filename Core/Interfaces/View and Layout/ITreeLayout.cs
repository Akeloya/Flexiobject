namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Tree layout interface
    /// </summary>
    public interface ITreeLayout : IBase
    {
        /// <summary>
        /// Add tree level
        /// </summary>
        /// <param name="ufd">User field id to form tree level</param>
        void AppendLevel(int ufd);
        /// <summary>
        /// Clear view
        /// </summary>
        void Clear();
        /// <summary>
        /// Get field forming tree level by index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>Field identifier</returns>
        int GetLevel(int idx);
    }
}