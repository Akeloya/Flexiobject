namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// State collection definition
    /// <see cref="IWorkflowDetails"/>
    /// <seealso cref="IStateTransitions"/>
    /// </summary>
    public interface IStateDefinitions : IBase
    {
        /// <summary>
        /// Create state
        /// </summary>
        /// <returns>New state object not belong to collection</returns>
        IState Create();
        /// <summary>
        /// Add early created state
        /// </summary>
        /// <param name="state">New state</param>
        void Add(IState state);
        /// <summary>
        /// Get state with initial flag (initial state)
        /// </summary>
        IState InitialState { get; }
        /// <summary>
        /// Remove state by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        void Remove(int idx);
        /// <summary>
        /// Remove state object
        /// </summary>
        /// <param name="state">State that will be removed</param>
        void Remove(IState state);
        /// <summary>
        /// Get state by index value
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns>IState object</returns>
        IState this[int idx] { get; }
        /// <summary>
        /// Access state object by it's alias
        /// </summary>
        /// <param name="alias">State alias</param>
        /// <returns>IState collection object</returns>
        IState this[string alias] { get; }
        /// <summary>
        /// State collection count
        /// </summary>
        int Count { get; }
    }
}