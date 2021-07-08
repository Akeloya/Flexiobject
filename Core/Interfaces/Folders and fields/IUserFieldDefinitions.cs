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
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Коллекция определений пользовательскиъ полей
    /// </summary>
    public interface IUserFieldDefinitions : IBaseCollection<IUserFieldDefinition>
    {
        /// <summary>
        /// Добавление нового определения пользовательского поля
        /// </summary>
        /// <param name="type">Тип пользовательского поля</param>
        /// <returns>IUserFieldDefinition объект нового определения</returns>
        IUserFieldDefinition Add(CoaFieldTypes type);
        /// <summary>
        /// Добавить пользовательское поле в коллекции
        /// </summary>
        /// <param name="field">Определение пользовательского поля</param>
        void AddExisting(IUserFieldDefinition field);
        /// <summary>
        /// Удаление поля из коллекции без удаления из БД.
        /// Метод может быть вызван только если объект используется в качестве контейнера
        /// </summary>
        /// <seealso cref="IsContainer"/>
        /// <param name="field"></param>
        void RemoveExisting(IUserFieldDefinition field);
        /// <summary>
        /// Флаг, обозначающий является ли текущий объект контейнером контейнером или нет.
        /// Если объект является контейнером, невозможно использовать методы Add, Delete
        /// Если объект не является контейнером, то невозможно использовать методы AddExisting, RemoveExisting
        /// </summary>
        bool IsContainer { get; }
    }
}