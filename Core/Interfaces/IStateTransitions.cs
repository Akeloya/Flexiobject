namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Transition collection
    /// </summary>
    public interface IStateTransitions : IBase
    {
        /// <summary>
        /// Add transition to collection
        /// </summary>
        /// <param name="transition">Early created transition</param>
        void Add(IStateTransition transition);
        /// <summary>
        /// Create new transition
        /// </summary>
        /// <returns></returns>
        IStateTransition Create();
        /// <summary>
        /// Remove transition by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        void Remove(int idx);
        /// <summary>
        /// Remove existing transition
        /// </summary>
        /// <param name="transition">Transition to remove</param>
        void Remove(IStateTransition transition);
        /// <summary>
        /// Collection count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access to transition by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IStateTransition this[int idx] { get; }        
    }
}