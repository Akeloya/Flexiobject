using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение настроек папки в которую импортируют данные
    /// </summary>
    public interface IImportFolderSettings : IBase
    {
        /// <summary>
        /// Тип импорта (добавление, добавление и изменение,...)
        /// </summary>
        FlexiImportSettingsTypes Type { get; set; }
        /// <summary>
        /// Необходимо ли создавать записи в истории
        /// </summary>
        bool CreateHistoryEntries { get; set; }
        /// <summary>
        /// Обновление автокалькуляции
        /// </summary>
        bool UpdateAutoCalculations { get; set; }
        /// <summary>
        /// Выполнение действий при работе с объектом
        /// </summary>
        bool ExecuteActions { get; set; }
        /// <summary>
        /// Проверка входных данных
        /// </summary>
        bool ValidateInput { get; set; }
    }
}