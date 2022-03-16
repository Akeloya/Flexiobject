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
    /// Интерфейс автоинкрементного идентификатора с префиксом и постфиксом
    /// </summary>
    public interface IAutoNumberDetailes : IBase
    {
        /// <summary>
        /// Длина поля
        /// </summary>
        int FieldWidth { get; set; }
        /// <summary>
        /// Наследовать настройки (родительской папки)
        /// </summary>
        bool InheritSettings { get; set; }
        /// <summary>
        /// Заполнять нолями слева число, добивая до длины
        /// </summary>
        bool LeadingZeroes { get; set; }
        /// <summary>
        /// Максимальное значение
        /// </summary>
        int MinimumValue { get; set; }
        /// <summary>
        /// Префикс числа
        /// </summary>
        string Prefix { get; set; }
        /// <summary>
        /// Распространять на дочерние папки
        /// </summary>
        bool ShareNumbersWithSubfolders { get; set; }
        /// <summary>
        /// Суффикс авто числа
        /// </summary>
        string Suffix { get; set; }
        /// <summary>
        /// Преобразование значения авточисла в число
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        long ConvertStringToNumber(string value);
    }
}