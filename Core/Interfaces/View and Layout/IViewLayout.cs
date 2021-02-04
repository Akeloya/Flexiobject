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
    /// Объект представляет объект IView (вывод может быть в виде списка, календаря, дерева)
    /// </summary>
    public interface IViewLayout : IBase
    {
        /// <summary>
        /// Папка визуального отображения данных
        /// </summary>
        IRequestFolder Folder { get; }
        /// <summary>
        /// Название вида
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Тип вида
        /// </summary>
        CoaViewTypes Type { get; set; }
        /// <summary>
        /// Добавить колонку к табличному виду
        /// </summary>
        /// <param name="column">Колонка</param>
        void AddColumnLayout(IColumnLayout column);
        /// <summary>
        /// Добавить колонку к древовидному виду.
        /// </summary>
        /// <param name="tree">Колонка</param>
        void AddTreeLayout(ITreeLayout tree);
        /// <summary>
        /// Получить табличное представление по папке и контексту
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        IColumnLayout GetColumnLayout(int folderId, int context);
        /// <summary>
        /// Получить древовидное представление по папке и контексту
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        ITreeLayout GetTreeLayout(int folderId, int context);
        /// <summary>
        /// Заменить пользовательское поле
        /// </summary>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        /// <returns></returns>
        long ReplaceUserfield(object oldVal, object newVal);
        /// <summary>
        /// Сохранить представление
        /// </summary>
        void Save();
    }
}