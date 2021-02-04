/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
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
namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Интерфейс доступа к истории изменения схемы сервера
    /// </summary>
    public interface ISchemaHistory : IBase
    {
        /// <summary>
        /// Получение записи изменения схемы истории по её индексу
        /// </summary>
        /// <param name="idx">0..Count-1 значение индекса</param>
        /// <returns>Объект записи истории</returns>
        ISchemaHistoryItem this[int idx] { get; }
        /// <summary>
        /// Количество записей истории в коллекции
        /// </summary>
        int Count { get; }
    }
}
