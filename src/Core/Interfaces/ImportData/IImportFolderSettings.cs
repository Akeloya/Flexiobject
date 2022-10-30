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
using System.Collections.Generic;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение настроек папки в которую импортируют данные
    /// </summary>
    public interface IImportFolderSettings : IBase
    {
        /// <summary>
        /// Тип импорта (добавление, добавление и изменение,...)
        /// </summary>
        CoaImportSettingsTypes Type { get; set; }
        /// <summary>
        /// Необходимо ли создавать записи в истории
        /// </summary>
        bool CreateHistoryEntries { get; set; }
        /// <summary>
        /// Обновление автокалькуляции
        /// </summary>
        bool UpdateAutoCalculations { get; set; }
        /// <summary>
        /// Выполнение действий при работе с объектом
        /// </summary>
        bool ExecuteActions { get; set; }
        /// <summary>
        /// Проверка входных данных
        /// </summary>
        bool ValidateInput { get; set; }
    }
}