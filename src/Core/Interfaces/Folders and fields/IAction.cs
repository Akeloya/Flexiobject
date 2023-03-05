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
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Действие выполняющееся автоматически при создании, изменении или удалении объекта
    /// </summary>
    public interface IAction : IBase
    {
        /// <summary>
        /// Ид действия
        /// </summary>
        int Id { get;}
        /// <summary>
        /// Тип действия
        /// </summary>
        FlexiActionTypes Type { get; set; } 
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Desctiption { get; set; }
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        /// <returns></returns>
        void Save();
    }
}