namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Import data
    /// </summary>
    public interface IImport : IBase
    {
        /// <summary>
        /// Run import with settings
        /// <param name="settings">IImportSettings or settings name</param>
        /// </summary>
        void Run(object settings);
        /// <summary>
        /// File path to logging data
        /// </summary>
        string LogFile { get; }
        /// <summary>
        /// String path to datasource
        /// </summary>
        string DataSource { get; set; }
    }
}