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
using System;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Активная (текущая) сессия пользователя
    /// </summary>
    public interface IActiveSession : IBase
    {
        /// <summary>
        /// Тип клиента
        /// </summary>
        string ClientType { get; }
        /// <summary>
        /// Хост пользователя
        /// </summary>
        string HostName { get; }
        /// <summary>
        /// Время логина
        /// </summary>
        DateTime LoginTime { get; }
        /// <summary>
        /// Время простоя (отсутствия трафика между клиентом и сервером)
        /// </summary>
        DateTime IdleTime { get; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Закрыть сессию
        /// </summary>
        void Close();
    }
}