namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Data import parameters
    /// </summary>
    public enum CoaImportSettingsTypes
    {
        /// <summary>
        /// Only adding new objects
        /// </summary>
        Add,
        /// <summary>
        /// New objects will be added, existing - modified
        /// </summary>
        AddModify,
        /// <summary>
        /// New objects will be added, existing - modified, not exisitng - deleted
        /// </summary>
        AddModifyDelete,
        /// <summary>
        /// Add records as new objects without checks
        /// </summary>
        AddNew,
        /// <summary>
        /// Only modify existing objects
        /// </summary>
        Modify,
        /// <summary>
        /// Only update references
        /// </summary>
        UpdateReferences
    }
}