namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Custom object collection
    /// </summary>
    public interface ICustomObjects : IBaseCollection<ICustomObject>
    {
        /// <summary>
        /// Add existing object to collection
        /// </summary>
        /// <param name="custObj">Adding object</param>
        void AddExisting(ICustomObject custObj);
        /// <summary>
        /// Add an existing object by identifier
        /// </summary>
        /// <param name="id">Object unique id</param>
        void AddExistingById(long id);
        /// <summary>
        /// Removing a link to an existing object
        /// </summary>
        /// <param name="variant">The ICustomObject or index in the object list to remove</param>
        void RemoveExisting(object variant);
        /// <summary>
        /// Deleting an existing object by Id
        /// </summary>
        /// <param name="id">The Id of the object to be deleted</param>
        void RemoveExistingById(long id);
        /// <summary>
        /// Restore object
        /// </summary>
        /// <param name="id">The Id of the object being restored</param>
        void Restore(long id);
        /// <summary>
        /// Delete object
        /// </summary>
        /// <param name="id">Object Id to delete</param>
        void Delete(long id);
    }
}