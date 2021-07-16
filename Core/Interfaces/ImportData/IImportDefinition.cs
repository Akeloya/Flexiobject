namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Import data definition
    /// </summary>
    public interface IImportDefinition : IBase
    {
        /// <summary>
        /// Definition name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Definition description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Import settings
        /// </summary>
        IImportSettings Definition { get; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}