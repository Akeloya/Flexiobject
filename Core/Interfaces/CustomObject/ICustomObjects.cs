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
namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Коллекция объектов
    /// </summary>
    public interface ICustomObjects : IBaseCollection<ICustomObject>
    {
        /// <summary>
        /// Добавить существующий объект в коллекцию
        /// </summary>
        /// <param name="request">Добавляемый объект</param>
        void AddExisting(ICustomObject request);
        /// <summary>
        /// Добавить существующийо бъект по идентификатору
        /// </summary>
        /// <param name="id">Ид объекта</param>
        void AddExistingById(long id);
        /// <summary>
        /// Удаление связи с существующим объектом
        /// </summary>
        /// <param name="variant">Удаляемый IRequest объект или индекс в списке объектов</param>
        void RemoveExisting(object variant);
        /// <summary>
        /// Удаление существующего объекта по ИД
        /// </summary>
        /// <param name="id">ИД удаляемого объекта</param>
        void RemoveExistingById(long id);
        /// <summary>
        /// Восстановить объект
        /// </summary>
        /// <param name="id">Ид восстанавливаемого объекта</param>
        /// <returns></returns>
        void Restore(long id);
        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="id">Ид удаляемого объекта</param>
        /// <returns></returns>
        void Delete(long id);
    }
}