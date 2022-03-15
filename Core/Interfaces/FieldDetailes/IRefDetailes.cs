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
using System.ComponentModel;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Дополнительная информация поля типа объект и список объектов
    /// </summary>
    public interface IRefDetailes : IBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Флаг операции каскадного копирования
        /// </summary>
        bool CascadeCopyOperations { get; set; }
        /// <summary>
        /// Индикатор операции каскадного удаление объектов
        /// </summary>
        bool CascadeDeleteOperations { get; set; }
        /// <summary>
        /// Папка по умолчанию, необходима при работе с дочерними объектами
        /// </summary>
        ICustomFolder DefaultFolder { get; set; }
        /// <summary>
        /// Скрипт папки по умолчанию
        /// </summary>
        IScript DefaultFolderScript { get; set; }
        /// <summary>
        /// Флаг использования скрипта для папки по умолчанию
        /// </summary>
        bool DefaultFolderUseScript { get; set; }
        /// <summary>
        /// Поле быстрого поиска объекта
        /// </summary>
        IUserFieldDefinition DefaultQuickSearchField { get; set; }
        /// <summary>
        /// Индикатор удаления ссылок на объект
        /// </summary>
        bool DeleteRefObjects { get; set; }
        /// <summary>
        /// Включение подпапок
        /// </summary>
        bool IncludeSubfolders { get; set; }
        /// <summary>
        /// Синхронизировано ли поле
        /// </summary>
        bool IsSynchronized { get; set; }
        /// <summary>
        /// Индикатор мастер-поля синхронизации
        /// </summary>
        bool MasterField { get; set; }
        /// <summary>
        /// Папка, связанная с полем
        /// </summary>
        ICustomFolder ReferencedFolder { get; set; }
        /// <summary>
        /// Флак идентифицирующий использование фильтра ограничения
        /// </summary>
        bool Restriction { get; set; }
        /// <summary>
        /// Флаг идентифицирующий ограничения только для выбранного объекта
        /// </summary>
        bool RestrictionOnlyForSelection { get; set; }
        /// <summary>
        /// Ошибка, выдаваемая пользователю при нарушении ограничения
        /// </summary>
        string RestrictionOptionalErrorMessage { get; set; }
        /// <summary>
        /// Сприкт ограничения
        /// </summary>
        IScript RestrictionScript { get; set; }
        /// <summary>
        /// Правило ограничения
        /// </summary>
        IRule RestrictionRule { get; set; }
        /// <summary>
        /// Флаг использования скрипта ограничения
        /// </summary>
        bool RestrictionUseScript { get; set; }
        /// <summary>
        /// Флаг симметричной синхронизации полей
        /// </summary>
        bool SymmetricSynchronization { get; set; }
        /// <summary>
        /// Поле синхронизации
        /// </summary>
        IUserFieldDefinition SynchronizedField { get; set; }
        /// <summary>
        /// Поля синхонизации
        /// </summary>
        IUserFieldDefinitions SynchronizedFields { get; set; }
        /// <summary>
        /// Получить папку по-умолчанию
        /// </summary>
        /// <returns></returns>
        ICustomFolder GetDefaultFolder();
        /// <summary>
        /// Получить фильтр ограничения на связанные объекты
        /// </summary>
        /// <returns></returns>
        IFilter GetRestrictionFilter();
    }
}