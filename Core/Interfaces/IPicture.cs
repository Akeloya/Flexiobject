namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Application picture
    /// </summary>
    public interface IPicture : IBase
    {
        /// <summary>
        /// Picture identifier
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Picture binary data
        /// </summary>
        byte[] Data { get; set; }
        /// <summary>
        /// Picture name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}