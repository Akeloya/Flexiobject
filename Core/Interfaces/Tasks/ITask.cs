using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Executable task on server
    /// </summary>
    public interface ITask : IBase
    {
        /// <summary>
        /// Task name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Task alias for access from API
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Task description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Task type
        /// </summary>
        CoaTaskTypes Type { get; set; }
        /// <summary>
        /// Task execution on folder
        /// </summary>
        ICustomFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Task detailes
        /// <see cref="Type"/>
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Execute task
        /// </summary>
        void Execute();
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}