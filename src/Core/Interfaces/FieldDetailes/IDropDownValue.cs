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
    /// Значение выпадающего списка
    /// </summary>
    public interface IDropDownValue : IBase
    {
        /// <summary>
        /// Алиас выпадающего значения
        /// </summary>
        string Alias { get; set; } 
        /// <summary>
        /// Описание выпадающего значение
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Название выпадающего значения
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Уровень, определяющий порядок в коллекции
        /// </summary>
        int Level { get; }
        /// <summary>
        /// Предшественник
        /// </summary>
        IDropDownValue Predecessor { get; }
        /// <summary>
        /// Преемник
        /// </summary>
        IDropDownValue Successor { get; }
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        int UniqueId { get; }
    }
}