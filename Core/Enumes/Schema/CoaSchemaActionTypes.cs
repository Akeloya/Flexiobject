namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Action collection of schema modification
    /// </summary>
    public enum CoaSchemaActionTypes
    {
        /// <summary>
        /// Creating folder
        /// </summary>
        Create = 1,
        /// <summary>
        /// Deleting folder
        /// </summary>
        Delete,
        /// <summary>
        /// Updating folder field
        /// </summary>
        Update,
        /// <summary>
        /// Rename folder
        /// </summary>
        Rename,
        /// <summary>
        /// Changing folder alias
        /// </summary>
        RenameAlias
    }
}
