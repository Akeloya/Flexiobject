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
using System.Collections.Generic;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Настройка импорта данных
    /// </summary>
    public interface IImportSettings : IBase
    {
        /// <summary>
        /// Тип импорта данных
        /// </summary>
        CoaImportDataTypes Type { get; set; } 
        /// <summary>
        /// Источник данных
        /// </summary>
        string DataSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IFieldMappings FieldMappings { get; }
        /// <summary>
        /// Настройки импорта данных
        /// </summary>
        IImportFolderSettings FolderSettings { get; }
        /// <summary>
        /// Использовать SQL запрос
        /// </summary>
        bool UseSql { get; set; }
        /// <summary>
        /// Использовать SQL 
        /// </summary>
        string SqlStatement { get; set; }
        /// <summary>
        /// Поля-идентификаторы
        /// </summary>
        List<string> IdentifyFields { get; }
        /// <summary>
        /// Логирование данных
        /// </summary>
        bool Logging { get; set; }
        /// <summary>
        /// Префикс файла логирования
        /// </summary>
        string LogPrefix { get; set; }
        /// <summary>
        /// Папка логирования импорта
        /// </summary>
        string LogFolder { get; set; }        
    }
}