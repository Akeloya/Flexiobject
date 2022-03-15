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
using Flexiobject.Core.Enumes;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Колонка результата запроса к данным
    /// </summary>
    public interface IQueryResultColumn : IBase
    {
        /// <summary>
        /// Название (по умолчанию Field.Label)
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Поле
        /// </summary>
        IUserFieldDefinition Field { get;}
        /// <summary>
        /// Путь к полю, которое требуется запросить.
        /// Для указания пути используется разделитель "." (точка).
        /// </summary>
        string FieldPath { get; set; }
        /// <summary>
        /// Если истина - возвращает конечные значения в виде строки, иначе - исходные значения в соответствие с типом данных
        /// </summary>
        bool AsString { get; set; }
        /// <summary>
        /// Функция аггрегирования данных
        /// </summary>
        CoaAggregateFunctionTypes Aggregation { get; set; }
    }
}