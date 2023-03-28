namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Связь полей
    /// </summary>
    public interface IFieldMapping : IBase
    {
        /// <summary>
        /// Источник
        /// </summary>
        string Source { get; } 
        /// <summary>
        /// Пользовательское поле
        /// </summary>
        IUserFieldDefinition Field { get; set; }
        /// <summary>
        /// Добавление к существующему контенту
        /// </summary>
        bool AppendExistingContent { get; set; }
    }
}