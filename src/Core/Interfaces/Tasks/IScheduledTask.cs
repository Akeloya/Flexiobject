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
    /// Запланированное серверное задание
    /// </summary>
    public interface IScheduledTask : IBase
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
        /// Расписание выполнение запланированной задачи
        /// </summary>
        ISchedule Schedule { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        FlexiScheduledTaskTypes Type { get; set; }
        /// <summary>
        /// Папка выполнения
        /// </summary>
        ICustomFolder ExecutionFolder { get; set; }
        /// <summary>
        /// Детали задания (В зависимости от типа)
        /// </summary>
        object Detailes { get; set; }
        /// <summary>
        /// Логирование результатов выполнения задания
        /// </summary>
        string ResultFileName { get; set; }
        /// <summary>
        /// Тип файла с результатами выполнения
        /// </summary>
        FlexiScheduledTaskResulFormatType ResultFileType { get; set; }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Save();
    }
}
