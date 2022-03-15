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
using System.Collections.Generic;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс коллекции действий модификации объектов
    /// </summary>
    public interface IActions : IBase
    {
        /// <summary>
        /// Добавить новое действие
        /// </summary>
        /// <returns></returns>
        IAction Add();
        /// <summary>
        /// Удалить действие
        /// </summary>
        /// <param name="variant"></param>
        void Remove(object variant);
        /// <summary>
        /// Количество действий в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к действию по индексу
        /// </summary>
        /// <param name="idx">0...Count-1 индекс действия</param>
        /// <returns></returns>
        IAction this[int idx] { get; }
        /// <summary>
        /// Изменение порядка действий при обработке
        /// </summary>
        /// <param name="left">Объект IAction или индекс 0...Count-1 коллекции</param>
        /// <param name="right">Объект IAction или индекс 0...Count-1 коллекции</param>
        void Swap(object left, object right);
    }
}