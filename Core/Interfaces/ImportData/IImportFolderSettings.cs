using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Determining the settings of the folder into which the data is imported
    /// </summary>
    public interface IImportFolderSettings : IBase
    {
        /// <summary>
        /// Import type
        /// </summary>
        CoaImportSettingsTypes Type { get; set; }
        /// <summary>
        /// Is it necessary to create records in history
        /// </summary>
        bool WriteHistory { get; set; }
        /// <summary>
        /// Autocalculation update
        /// </summary>
        bool UpdateAutoCalculations { get; set; }
        /// <summary>
        /// Performing actions when working with an object
        /// </summary>
        bool ExecuteActions { get; set; }
        /// <summary>
        /// Input validation
        /// </summary>
        bool ValidateInput { get; set; }
    }
}