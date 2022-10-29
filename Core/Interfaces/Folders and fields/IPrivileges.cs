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
namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция разрешений для папки
    /// </summary>
    public interface IPrivileges : IBase
    {
        /// <summary>
        /// Создать новое разрешение. Изменения применятся после сохранения объекта.
        /// <see cref="IPrivilege.Save"/>
        /// </summary>
        /// <returns>Объект IPermission</returns>
        IPrivilege Add();
        /// <summary>
        /// Удаление записи из коллекции по индексу
        /// </summary>
        /// <param name="index">0..Count-1 индекс</param>
        void Remove(int index);
        /// <summary>
        /// Удаление записи из коллекции. Запись должна принадлежать коллекции
        /// </summary>
        /// <param name="obj">Удаляемый объект <see cref="IPrivilege"/></param>
        void Remove(IPrivilege obj);
        /// <summary>
        /// Количество привелегий
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Получение привелегии по индексу
        /// </summary>
        /// <param name="index">0...Count-1 значение индекса</param>
        /// <returns>Объект <see cref="IPrivilege"/></returns>
        IPrivilege this[int index] { get; }
    }
}
