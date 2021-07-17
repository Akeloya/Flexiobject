namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Custom folder privilegies collection
    /// </summary>
    public interface IPrivileges : IBase
    {
        /// <summary>
        /// Add new privilegies. Changes will applied after it will be saved
        /// <see cref="IPrivilege.Save"/>
        /// </summary>
        /// <returns>IPrivilege object</returns>
        IPrivilege Add();
        /// <summary>
        /// Remove privilege from collection by index
        /// </summary>
        /// <param name="index">0..Count-1 index value</param>
        void Remove(int index);
        /// <summary>
        /// Remove privilege from collection
        /// </summary>
        /// <param name="obj">Object that must be removed <see cref="IPrivilege"/></param>
        void Remove(IPrivilege obj);
        /// <summary>
        /// Privilege collection count
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Access privilege by index
        /// </summary>
        /// <param name="index">0...Count-1 index value</param>
        /// <returns>Privilege object <see cref="IPrivilege"/></returns>
        IPrivilege this[int index] { get; }
    }
}
