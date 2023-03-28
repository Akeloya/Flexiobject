namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение импорта данных
    /// </summary>
    public interface IImportDefinition : IBase
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Определение настроек
        /// </summary>
        IImportSettings Definition { get; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        void Save();
    }
}