using CoaApp.Core.Enumes;
using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Base user object in application
    /// </summary>
    public interface ICustomObject : IBase, IEquatable<ICustomObject>
    {
        /// <summary>
        /// Unique identifier of object
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Object name from folder naming schema
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Object created date-time
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// Object fields defined in folder
        /// </summary>
        IUserFields UserFields { get; }
        /// <summary>
        /// Object history changes
        /// </summary>
        IHistory History { get; }
        /// <summary>
        /// Save object
        /// </summary>
        void Save(CoaEnumSaveFlags flags);
        /// <summary>
        /// Removing object
        /// </summary>
        /// <param name="skipTrashbin">Skip trash bin. By default object removed in trash bin, and after it's cleared - from database</param>
        /// <param name="ignoreReferences">Ignore references to another objects</param>
        /// <param name="flags">Deletion parameters</param>
        void Delete(bool skipTrashbin = false, bool ignoreReferences = false, CoaDeletionObjectFlags? flags = null);
        /// <summary>
        /// Parent folder, which object belongs to
        /// </summary>
        ICustomFolder CustomObjFolder { get; }
        /// <summary>
        /// Get modified object state
        /// </summary>
        bool IsModified { get; }
    }
}