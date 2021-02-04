﻿/*
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
    /// Задание для выполнения на сервере
    /// </summary>
    public interface ITask : IBase
    {
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Алиас для доступа из API
        /// </summary>
        string Alias { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        CoaTaskTypes Type { get; set; }
        /// <summary>
        /// Папка выполнения
        /// </summary>
        IRequestFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Детали задания (В зависимости от типа)
        /// 
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Запуск выполнения
        /// </summary>
        void Execute();
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Save();
    }
}