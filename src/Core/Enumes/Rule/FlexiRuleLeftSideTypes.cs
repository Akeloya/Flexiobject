using System;

namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Left side operand type
    /// </summary>
    [Serializable]
    public enum FlexiRuleLeftSideTypes
    {
        /// <summary>
        /// Left side is field path
        /// </summary>
        FieldPath,
        /// <summary>
        /// Left side is object unique id
        /// </summary>
        UniqueId,
        /// <summary>
        /// Left side is current user
        /// </summary>
        CurrentUser,
        /// <summary>
        /// Left side is client type
        /// </summary>
        CurrentClient,
        /// <summary>
        /// Left side is context compare object
        /// </summary>
        Context,
        /// <summary>
        /// Left side is named rule
        /// </summary>
        NamedRule,
        /// <summary>
        /// Left side is folder
        /// </summary>
        Folder,
        /// <summary>
        /// Left side is folder alias
        /// </summary>
        FolderAliasName,
        /// <summary>
        /// Left side is folder name
        /// </summary>
        FolderName,
        /// <summary>
        /// Left side is items count
        /// </summary>
        Count
    }
}
