namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Scheduled tasks collection
    /// </summary>
    public interface IScheduledTasks : IBase
    {
        /// <summary>
        /// Access to shceduled task by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IScheduledTask this[int idx] { get; }
        /// <summary>
        /// Access to scheduled task by alias
        /// </summary>
        /// <param name="alias">Scheduled task alias</param>
        /// <returns></returns>
        IScheduledTask this[string alias] { get; }
        /// <summary>
        /// Collection count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Add new scheduled task
        /// </summary>
        /// <returns></returns>
        IScheduledTask Add();
        /// <summary>
        /// Delete scheduled task
        /// </summary>
        /// <param name="variant">Scheduled task object or element collection index</param>
        void Delete(dynamic variant);
    }
}
