using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Script history changes record
    /// </summary>
    public interface IScriptHistoryItem : IBase
    {
        /// <summary>
        /// Modification date
        /// </summary>
        DateTime Modified { get; }
        /// <summary>
        /// Created date
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// Script text
        /// </summary>
        string Script { get; }
        /// <summary>
        /// Is version published
        /// </summary>
        bool IsPublished { get; }
        /// <summary>
        /// Published date
        /// </summary>
        DateTime PublishedDate { get; }
        /// <summary>
        /// Publisher
        /// </summary>
        IUser PublishedBy { get; }
        /// <summary>
        /// Creator
        /// </summary>
        IUser CreatedBy { get; }
        /// <summary>
        /// Modifier
        /// </summary>
        IUser ModifiedBy { get; }
    }
}
