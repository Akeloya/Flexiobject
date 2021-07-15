namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Privilege levelse collection
    /// </summary>
    public enum CoaEnumPrivilegeLevel : byte
    {
        /// <summary>
        /// User or group will not have privilegies to folder and it's object
        /// </summary>
        NoPrivilege,
        /// <summary>
        /// User or group will can read objects
        /// </summary>
        ReadOnly,
        /// <summary>
        /// Previlegies allow to modificate User objects
        /// </summary>
        ReadWrite,
        /// <summary>
        /// Previlegies allow to modificate Folder objects
        /// </summary>
        Administration
    }
}