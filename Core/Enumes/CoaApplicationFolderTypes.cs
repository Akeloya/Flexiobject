namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Коллекция предустановленных папок приложения
    /// Коллекция используется для связывания пользовательских папок и папок приложения
    /// </summary>
    public enum CoaApplicationFolderTypes : byte
    {
        /// <summary>
        /// Application user folder 
        /// </summary>        
        UserAccounts = 1,
        /// <summary>
        /// Application user groups
        /// </summary>        
        UserGroups = 2
    }
}