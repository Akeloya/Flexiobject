using System;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс поиска записей в истории изменени объектов
    /// </summary>
    public interface IHistorySearch : IBase
    {
        /// <summary>
        /// Начальная дата фильтрации
        /// </summary>
        DateTime EndDate { get; set; }
        /// <summary>
        /// Конечная дата фильтрации
        /// </summary>
        DateTime StartDate { get; set; }
    }
}