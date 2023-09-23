using System;

namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Deletion parameter flags
    /// </summary>
    [Flags]
    public enum FlexiDeletionObjectFlags
    {
        /// <summary>
        /// Do not check permission for object deletion action
        /// </summary>
        WithoutPermissionCheck,
        /// <summary>
        /// Do not run actions
        /// </summary>
        WithoutActions,
        /// <summary>
        /// Clear deletion - no any 
        /// </summary>
        ClearDeletion
    }
}
