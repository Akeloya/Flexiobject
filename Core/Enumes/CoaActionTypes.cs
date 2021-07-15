namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Коллекция типов действий модификаций объектов
    /// </summary>
    public enum CoaActionTypes
    {
        /// <summary>
        /// Modifieng object data
        /// </summary>
        ModifyObject,
        /// <summary>
        /// Email message
        /// </summary>
        Email,
        /// <summary>
        /// Executing command
        /// </summary>
        Command,
        /// <summary>
        /// C# extension action
        /// </summary>
        CScode,
        /// <summary>
        /// Уведомление
        /// </summary>
        Notification,
    }
}