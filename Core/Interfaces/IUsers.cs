namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Application user collection
    /// </summary>
    public interface IUsers : IBaseCollection<IUser>
    {
        /// <summary>
        /// Get user by login name
        /// </summary>
        /// <param name="login">User login name</param>
        /// <returns>Object IUser</returns>
        IUser GetUserByLoginName(string login);        
    }
}