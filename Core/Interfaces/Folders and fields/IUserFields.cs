namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User field collection of ICustomObject
    /// <seealso cref="ICustomObject"/>
    /// </summary>
    public interface IUserFields : IBase
    {
        /// <summary>
        /// Field count in collection
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access to field by index
        /// </summary>
        /// <param name="idx">0 - Count-1 index value</param>
        /// <returns>IUserField object <seealso cref="IUserField"/></returns>
        IUserField this[int idx] { get; }
        /// <summary>
        /// Access to field by it's alias
        /// </summary>
        /// <param name="alias">Field alias</param>
        /// <returns>IUserField object <seealso cref="IUserField"/></returns>
        IUserField this[string alias] { get; }        
    }
}