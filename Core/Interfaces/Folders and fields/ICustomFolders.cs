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
    /// Коллекция папкок
    /// </summary>
    public interface ICustomFolders : IBaseCollection<ICustomFolder>
    {
        /// <summary>
        /// Добавить новую папку
        /// </summary>
        /// <param name="name">Имя папки</param>
        /// <param name="alias">Алиас папки</param>
        /// <param name="parentFolder">Родительская папка</param>
        /// <returns></returns>
        ICustomFolder Add(string name, string alias, ICustomFolder parentFolder);
        /// <summary>
        /// Удаление папки
        /// </summary>
        /// <param name="id">Ид папки</param>
        /// <param name="force">Игнорировать наличие в папке объектов</param>
        void Remove(int id, bool force = false);
        /// <summary>
        /// Удаление папки
        /// </summary>
        /// <param name="folder">Папка для удаления</param>
        /// <param name="force">Игнорирование наличия в папке объектов</param>
        void Remove(ICustomFolder folder, bool force = false);
        /// <summary>
        /// Доступ к элементу коллекции по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор папки</param>
        /// <returns>IRequestFolder/null</returns>
    }
}