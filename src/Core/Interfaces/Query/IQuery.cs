﻿namespace FlexiObject.Core.Interfaces
{

    /// <summary>
    /// Запрос к данным
    /// </summary>
    public interface IQuery : IBase
    {
        /// <summary>
        /// Флаг фильтрации одинаковых объектов
        /// </summary>
        bool Distinct { get; set; }
        /// <summary>
        /// Фильтр объектов запроса
        /// </summary>
        IFilter Filter { get; set; }
        /// <summary>
        /// Добавление колонки для запроса данных, которая должна попасть в итог
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IQueryResultColumn AddColumn(string name);
        /// <summary>
        /// Поле группировки
        /// </summary>
        /// <param name="field"></param>
        void AddGroupField(object field);
        /// <summary>
        /// Запрос истории объекта
        /// </summary>
        void AddHistorySearch();
        /// <summary>
        /// Поле сортировки
        /// </summary>
        /// <param name="field"></param>
        /// <param name="descending"></param>
        void AddSortField(object field, bool descending = false);
        /// <summary>
        /// Вызов запроса к данным
        /// </summary>
        /// <returns></returns>
        IQueryResult Execute();

    }
}
