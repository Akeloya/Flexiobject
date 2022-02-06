namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Pictures collection
    /// </summary>
    public interface IPictures : IBase
    {
        /// <summary>
        /// Add new picture
        /// </summary>
        /// <returns></returns>
        IPicture Add();
        /// <summary>
        /// Access picture by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IPicture this[int idx] { get; }
        /// <summary>
        /// Picture count
        /// </summary>
        /// <returns></returns>
        int Count { get; }
        /// <summary>
        /// Remove picture by index
        /// </summary>
        /// <param name="idx">0.Count-1 index value</param>
        void Remove(int idx);
    }
}