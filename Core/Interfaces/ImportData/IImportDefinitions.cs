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
namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Коллекция настроек импорта данных
    /// </summary>
    public interface IImportDefinitions : IBase
    {
        /// <summary>
        /// Размер коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к элементу коллекции по индексу
        /// </summary>
        /// <param name="idx">Индекс коллекции 0...Count-1</param>
        /// <returns></returns>
        IImportDefinition this[int idx] { get; }
        /// <summary>
        /// Доступ к элементу коллекции по названию
        /// </summary>
        /// <param name="name">Название настройки</param>
        /// <returns></returns>
        IImportDefinition this[string name] { get; }
        /// <summary>
        /// Добавление новой настройки импорта данных
        /// </summary>
        /// <param name="folder">Папка для которой добавляется настройка импорта данных</param>
        /// <returns></returns>
        IImportDefinition Add(IRequestFolder folder);
        /// <summary>
        /// Удаление настройки импорта данных
        /// </summary>
        /// <param name="variant"></param>
        void Remove(object variant);
    }
}