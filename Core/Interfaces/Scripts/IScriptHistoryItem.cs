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

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Элемент записи истории
    /// </summary>
    public interface IScriptHistoryItem : IBase
    {
        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTime Modified { get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// Текст скрипта
        /// </summary>
        string Script { get; }
        /// <summary>
        /// Флаг факта публикации. Допускается только одно значение "истина" среди записей в истории
        /// </summary>
        bool IsPublished { get; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        DateTime PublishedDate { get; }
        /// <summary>
        /// Кем опубликованно
        /// </summary>
        IUser PublishedBy { get; }
        /// <summary>
        /// Кем создано
        /// </summary>
        IUser CreatedBy { get; }
        /// <summary>
        /// Кем изменено
        /// </summary>
        IUser ModifiedBy { get; }
    }
}
