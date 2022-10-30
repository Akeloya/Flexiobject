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
    /// Доступ к коллекции запланированных задач
    /// </summary>
    public interface ITasks : IBase
    {
        /// <summary>
        /// Добавление новой запланированной задачи
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ITask Add(short type);
        /// <summary>
        /// Удаление задания
        /// </summary>
        /// <param name="variant">Удаляемый объект или индекс 0...Count-1</param>
        void Remove(object variant);
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">0..Count-1 индекс коллекции</param>
        /// <returns>ITask объект коллекции</returns>
        ITask this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции по ITask.Alias
        /// </summary>
        /// <param name="alias">Строка-алиас запланированной задачи</param>
        /// <returns>ITask объект коллекции</returns>
        ITask this[string alias] { get; }
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
    }
}