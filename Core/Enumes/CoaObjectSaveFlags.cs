using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// ICustomObject save flags
    /// </summary>
    [Flags]
    public enum CoaEnumSaveFlags
    {
        /// <summary>
        /// No saving flags - default value
        /// </summary>
        NoFlags = 0,
        /// <summary>
        /// Don't check permissions
        /// </summary>
        DoNotCheckPermission = 1,
        /// <summary>
        /// Don't check data:
        /// - Regular expressions
        /// - Restriction filters
        /// - Non defined or incorrect workflow state
        /// - Correct placement of related objects
        /// - Autonumeration corrected
        /// - Empty required fields
        /// </summary>
        DoNotValidateInput = 2,
        /// <summary>
        /// Don't execute actions on folder
        /// </summary>
        DoNotExecuteActions = 4,
        /// <summary>
        /// Don't write any history changes
        /// </summary>
        DoNotUpdateHistory = 8,
        /// <summary>
        /// Don't recalculate autocalculations
        /// </summary>
        DoNotRecalcAutocalculations = 16,
        /// <summary>
        /// Don't check permissions
        /// </summary>
        DoNotCheckPrivileges = 32,
        /// <summary>
        /// Don't check last changed fields
        /// </summary>
        DoNotChangeLastChangeFields = 64
    }
}
