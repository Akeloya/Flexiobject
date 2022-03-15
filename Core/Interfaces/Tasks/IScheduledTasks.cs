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
namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Коллекция запланированных заданий на сервере
    /// </summary>
    public interface IScheduledTasks : IBase
    {
        /// <summary>
        /// Доступ к элементу коллекции по индексу
        /// </summary>
        /// <param name="idx">Индекс 0..Count-1</param>
        /// <returns></returns>
        IScheduledTask this[int idx] { get; }
        /// <summary>
        /// Доступ к элементу коллекции по алиасу
        /// </summary>
        /// <param name="alias">Строка - алиас запланированного задания в коллекции</param>
        /// <returns></returns>
        IScheduledTask this[string alias] { get; }
        /// <summary>
        /// Количество запланированных заданий в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Добавить новое запланированное задание
        /// </summary>
        /// <returns></returns>
        IScheduledTask Add();
        /// <summary>
        /// Удаление запланированного задания
        /// </summary>
        /// <param name="variant">Индекс или IScheduledTask объект, удаляемый с сервера</param>
        void Delete(dynamic variant);
    }
}
