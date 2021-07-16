namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Detailes for option list
    /// </summary>
    public interface IOptionListDetailes : IBase
    {
        /// <summary>
        /// Collection element count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Default value
        /// </summary>
        IOptionListValue DefaultValue { get; set; }
        /// <summary>
        /// Highest value
        /// </summary>
        IOptionListValue Highest { get; }
        /// <summary>
        /// Lowest value
        /// </summary>
        IOptionListValue Lowest { get; }
        /// <summary>
        /// Access to option list by index
        /// </summary>
        /// <param name="idx">0..Count-1 index value</param>
        /// <returns></returns>
        IOptionListValue this[int idx] { get; }
        /// <summary>
        /// Access to option list by it's alias
        /// </summary>
        /// <param name="alias">Option list value alias</param>
        /// <returns></returns>
        IOptionListValue this[string alias] { get; }
        /// <summary>
        /// Create new option list. For add it to collection use 'InsertAt'
        /// <see cref="InsertAt(IOptionListValue, int)"/>
        /// </summary>
        /// <returns>IOptionListValue объект</returns>
        IOptionListValue Create();
        /// <summary>
        /// Add early created IOptionListValue object to collection
        /// </summary>
        /// <param name="val">IOptionListValue adding object</param>
        /// <param name="idx">0...Count-1 inserting index</param>
        void InsertAt(IOptionListValue val, int idx);
        /// <summary>
        /// Remove element collection by index
        /// </summary>
        /// <param name="idx">0..Count-1 index of removing element</param>
        void Remove(int idx);
        /// <summary>
        /// Swapping of two elements
        /// </summary>
        /// <param name="idx1">0...Count-1 index value of first element</param>
        /// <param name="idx2">0...Count-1 index value of second element</param>
        void Swap(int idx1, int idx2);
    }
}