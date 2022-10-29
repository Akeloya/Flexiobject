/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace FlexiObject.Core.Interfaces
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
