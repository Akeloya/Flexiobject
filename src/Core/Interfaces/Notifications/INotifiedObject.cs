﻿/*
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
using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotifiedObject : IBase
    {
        /// <summary>
        /// Уведомить получателя о событии
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="linkedObject">Связанный объект</param>
        void Notify(string message, object linkedObject);
        /// <summary>
        /// Коллекция уведомлений пользователя
        /// </summary>
        /// <returns><seealso cref="INotifiedMessages"/> объект коллекции</returns>
        INotifiedMessages Messages { get; }
    }
}
