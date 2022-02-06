using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Task collection
    /// </summary>
    public interface ITasks : IBase
    {
        /// <summary>
        /// Add new task
        /// </summary>
        /// <param name="type">Adding task type</param>
        /// <returns></returns>
        ITask Add(CoaTaskTypes type);
        /// <summary>
        /// Remove task
        /// </summary>
        /// <param name="variant">Collection index 0...Count-1 or ITask object</param>
        void Remove(object variant);
        /// <summary>
        /// Access to task by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns>ITask object</returns>
        ITask this[int idx] { get; }
        /// <summary>
        /// Access to task by it's alias
        /// </summary>
        /// <param name="alias">Task alias string</param>
        /// <returns>ITask object</returns>
        ITask this[string alias] { get; }
        /// <summary>
        /// Collection element count
        /// </summary>
        int Count { get; }
    }
}