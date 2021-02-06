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
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Обсновной объект приложения
    /// </summary>
    public interface ICustomObject : IBase
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Название объекта, формируемое из схемы
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Пользовательские поля объекта
        /// </summary>
        IUserFields UserFields { get; }
        /// <summary>
        /// История изменения объекта
        /// </summary>
        IHistory History { get; }
        /// <summary>
        /// Сохранение объекта
        /// </summary>
        void Save();//TODO:модифицировать метод для передачи флага правила сохранения объекта, чтобы отключать модификации, калькуляции и т.д.
        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="skipTrashbin">Пропустить при удалении корзину</param>
        /// <param name="ignoreReferences">Проигнорировать ссылки при удалении</param>
        /// <param name="flags">Параметры удаления объекта</param>
        /// <returns></returns>
        void Delete(bool skipTrashbin = false, bool ignoreReferences = false, CoaDeletionObjectFlags? flags = null);
        /// <summary>
        /// Родительская папка объекта
        /// </summary>
        ICustomFolder RequestFolder { get; }
        /// <summary>
        /// Получение состояние модификации объекта
        /// </summary>
        bool IsModified { get; }
    }
}