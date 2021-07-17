using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Scheduled task on server
    /// </summary>
    public interface IScheduledTask : IBase
    {
        /// <summary>
        /// Task name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Task alias to access from API
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Task description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Task schedule
        /// </summary>
        ISchedule Schedule { get; set; }
        /// <summary>
        /// Task type
        /// </summary>
        CoaScheduledTaskTypes Type { get; set; }
        /// <summary>
        /// Task execute on folder
        /// </summary>
        ICustomFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Task detailes
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Task execution results file name
        /// </summary>
        string ResultFileName { get; set; }
        /// <summary>
        /// Execution results file
        /// </summary>
        CoaScheduledTaskResulFormatType ResultFileType { get; set; }
        /// <summary>
        /// Save changes
        /// </summary>
        void Save();
    }
}
