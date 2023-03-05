namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Authentication types
    /// </summary>
    public enum FlexiUserAuthTypes
    {
        NoAuth,
        /// <summary>
        /// User login and password stores in database
        /// </summary>
        Internal,
        /// <summary>
        /// Windows login and domain get in user logged in environment and transfer to server for check
        /// </summary>
        Windows        
    }
}
