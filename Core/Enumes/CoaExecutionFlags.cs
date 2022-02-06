using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Execution flags
    /// </summary>
    [Flags]
    public enum CoaExecutionFlags : byte
    {
        /// <summary>
        /// Do not check permissions
        /// </summary>
        DoNotCheckPermissions = 1,
        /// <summary>
        /// Do not check privileges
        /// </summary>
        DoNotCheckPrivileges,
        /// <summary>
        /// Do not validate imput data
        /// </summary>
        DoNotValidateInput,
        /// <summary>
        /// Do not checks identity fields
        /// </summary>
        DoNotCheckForIdentityFields,
        /// <summary>
        /// Do not execute any actions
        /// </summary>
        DoNotExecuteActions,
        /// <summary>
        /// Do not recalculate escalation datetimes
        /// </summary>
        DoNotRecalculateEscalationTimes,
        /// <summary>
        /// Do not create history entries
        /// </summary>
        DoNotCreateHistoryEntries,
        /// <summary>
        /// Do not update any autocalculation on folder for object
        /// </summary>
        DoNotUpdateAutocalculations
    }
}