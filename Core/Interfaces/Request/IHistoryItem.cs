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
using System;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Запись в истории объекта
    /// </summary>
    public interface IHistoryItem : IBase
    {
        /// <summary>
        /// Действие
        /// </summary>
        CoaHistoryActionTypes Action { get; }
        /// <summary>
        /// Дата-время изменения
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// текстовое описание события
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Новое значение
        /// </summary>
        string NewValue { get; }
        /// <summary>
        /// Старое значение
        /// </summary>
        string OldValue { get; }
        /// <summary>
        /// Информация о состоянии объекта в момент изменения
        /// </summary>
        IState State { get; }
        /// <summary>
        /// Пользователь, вызвавший изменения
        /// </summary>
        IUser User { get;}
        /// <summary>
        /// Поле, которое было изменено.
        /// </summary>
        IUserFieldDefinition UserField { get; }
        /// <summary>
        /// Имя пользователя IUser.Object.Name
        /// </summary>
        string UserName { get; }
    }
}