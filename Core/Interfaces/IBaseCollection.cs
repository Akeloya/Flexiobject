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
using Flexiobject.Core.Interfaces;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Коллекция форм и правил их отображения
    /// </summary>
    public interface IBaseCollection<T>
    {
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="index">0..Count-1 номер индекса</param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="name">Имя объекта, если имеется</param>
        /// <returns></returns>
        T this[string name] { get; }
        /// <summary>
        /// Добавить 
        /// </summary>
        /// <returns>объект коллекции</returns>
        T Add();
        /// <summary>
        /// Удалить объект коллекции
        /// </summary>
        /// <param name="obj">объект, удаляемый из коллекции</param>
        void Remove(T obj);
        /// <summary>
        /// Удалить объект коллекции
        /// </summary>
        /// <param name="index">номер индекса, удаляемый из коллекции</param>
        void Remove(int index);
        /// <summary>
        /// Количество 
        /// </summary>
        int Count { get; }
    }
}
