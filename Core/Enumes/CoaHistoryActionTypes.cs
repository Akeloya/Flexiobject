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
namespace Flexiobject.Core.Enumes
{
    /// <summary>
    /// Коллекция типов записей истории изменения объектов
    /// </summary>
    public enum CoaHistoryActionTypes
    {
        /// <summary>
        /// Объект создан
        /// </summary>
        ObjCreated = 1,
        /// <summary>
        /// Удаление объекта
        /// </summary>
        ObjDeleted,
        /// <summary>
        /// Object was restored from trashbin
        /// </summary>
        ObjRestored,
        /// <summary>
        /// Object was copied
        /// </summary>
        ObjCopied,
        /// <summary>
        /// Изменено пользовательское поле
        /// </summary>
        FieldModified,
        /// <summary>
        /// Изменен список объектов
        /// </summary>
        ModifyObjectLIst,
        /// <summary>
        /// Перемещение вложения
        /// </summary>
        AttachmentMoved,
        /// <summary>
        /// Добавление ссылки
        /// </summary>
        ReferenceAdded,
        /// <summary>
        /// Удаление ссылки
        /// </summary>
        ReferenceRemoved,
        /// <summary>
        /// Добавлено вложение
        /// </summary>
        AttachmentAdded,
        /// <summary>
        /// Вложение удалено
        /// </summary>
        AttachmentDeleted,
        /// <summary>
        /// Изменение вложения
        /// </summary>
        AttachmentModified,
        /// <summary>
        /// Изменение описания вложения
        /// </summary>
        AttachmentDescriptionModified,
        /// <summary>
        /// Создание схемы импорта
        /// </summary>
        CreatedSchemaImport
    }
}