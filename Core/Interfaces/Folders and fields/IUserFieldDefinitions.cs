using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User field definition collection
    /// <see cref="IUserFieldDefinition"/>
    /// <see cref="ICustomFolder"/>
    /// <seealso cref="ICustomObject"/>
    /// </summary>
    public interface IUserFieldDefinitions : IBaseCollection<IUserFieldDefinition>
    {
        /// <summary>
        /// Adding a new custom field definition
        /// </summary>
        /// <param name="type">User field type</param>
        /// <returns>IUserFieldDefinition object</returns>
        IUserFieldDefinition Add(CoaFieldTypes type);
        /// <summary>
        /// Add custom field to collections
        /// </summary>
        /// <param name="field">Existing user field definition object</param>
        void AddExisting(IUserFieldDefinition field);
        /// <summary>
        /// Deleting a field from a collection without deleting it from the database.
        /// The method can only be called if the object is used as a container
        /// </summary>
        /// <seealso cref="IsContainer"/>
        /// <param name="field"></param>
        void RemoveExisting(IUserFieldDefinition field);
        /// <summary>
        /// A flag indicating whether the current object is a container or not. 
        /// If the object is a container, you cannot use the Add, Delete methods 
        /// If the object is not a container, then you cannot use the AddExisting, RemoveExisting methods
        /// </summary>
        bool IsContainer { get; }
    }
}