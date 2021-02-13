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
    /// Интерфейс записи истории схемы изменения папок и связанных объектов
    /// </summary>
    public interface ISchemaHistoryItem : IBase
    {
        /// <summary>
        /// Дата события
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Тип события
        /// </summary>
        CoaSchemaEventTypes Type { get; }
        /// <summary>
        /// Ид записи в базе связанного объекта
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// Пользовательское имя
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Ид связанного удалённого объекта
        /// </summary>
        int DeletedRef { get; }
        /// <summary>
        /// Старое название объекта
        /// </summary>
        string OldName { get; }
        /// <summary>
        /// Новое название объекта
        /// </summary>
        string NewName { get; }
        /// <summary>
        /// Действие над объектом
        /// </summary>
        CoaSchemaActionTypes Action { get; }
        /// <summary>
        /// Версия сервера приложений во время изменения объекта
        /// </summary>
        string Version { get; }
        /// <summary>
        /// Сетевой адрес компьютера с клиентом, с которого производились изменения
        /// </summary>
        string IPAddress { get; }
    }
}
