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
using System.Collections.Generic;
using System.ComponentModel;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Код (скрипт) c# для выполнения
    /// </summary>
    public interface IScript : IBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Ид скрипта
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Скрипт/код
        /// </summary>
        string Script { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        CoaScriptTypes Type { get; set; }
        /// <summary>
        /// Ссылка на форме
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// Флаг построения скрипта
        /// </summary>
        bool Builded { get; }
        /// <summary>
        /// Сохранение изменений с построением
        /// </summary>
        /// <returns>Список ошибок при построении</returns>
        List<string> Save();
        /// <summary>
        /// Построение или перестроение скрипта
        /// </summary>
        /// <returns>Ошибки, возникшие во время построения</returns>
        List<string> Build();
        /// <summary>
        /// Публикация версии в качестве текущей
        /// </summary>
        /// <returns>Список ошибок, либо null. Если имеется список ошибок, то публикация провалилась.</returns>
        List<string> Publish();
            /// <summary>
        /// Последнее время построения
        /// </summary>
        DateTime? BuildedTime { get;}     
        /// <summary>
        /// Ошибки построения скрипта
        /// </summary>
        List<string> Errors { get; }
        /// <summary>
        /// Папка скрипта
        /// </summary>
        IRequestFolder Folder { get; }
        /// <summary>
        /// История изменения скрипта
        /// </summary>
        IScriptHistoryItems HistoryItems { get; }
    }
}