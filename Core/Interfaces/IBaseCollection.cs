namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Base typed object collection
    /// </summary>
    public interface IBaseCollection<T>: IBase
    {
        /// <summary>
        /// Acces object in collection by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// Access object in collection by name or string key
        /// </summary>
        /// <param name="name">Name of object or string key</param>
        /// <returns></returns>
        T this[string name] { get; }
        /// <summary>
        /// Add new object to collection 
        /// </summary>
        /// <returns>Created object. Object will be added to collection after it saved</returns>
        T Add();
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="obj">Object for removing</param>
        void Remove(T obj);
        /// <summary>
        /// Remove object
        /// </summary>
        /// <param name="index">Index number for removing object</param>
        void Remove(int index);
        /// <summary>
        /// Object collection count 
        /// </summary>
        int Count { get; }
    }
}
