namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Action collection
    /// </summary>
    public interface IActions : IBase
    {
        /// <summary>
        /// Add new action
        /// </summary>
        /// <returns></returns>
        IAction Add();
        /// <summary>
        /// Remove action from collection
        /// </summary>
        /// <param name="variant">IAction object or index</param>
        void Remove(object variant);
        /// <summary>
        /// Action colleciton count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access to action by index
        /// </summary>
        /// <param name="idx">0...Count-1 index value</param>
        /// <returns></returns>
        IAction this[int idx] { get; }
        /// <summary>
        /// Swap to action places
        /// </summary>
        /// <param name="left">IAction object or 0...Count-1 index value</param>
        /// <param name="right">IAction object or 0...Count-1 index value</param>
        void Swap(object left, object right);
    }
}