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
using Flexiobject.Core.Enumes;
using System.Drawing;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс формы приложения
    /// </summary>
    public interface IForm : IBase
    {
        /// <summary>
        /// Название формы в БД
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Заголовок формы в ПИ
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Ширина окна формы
        /// </summary>
        double Width { get; set; }
        /// <summary>
        /// Высота окна формы
        /// </summary>
        double Height { get; set; }
        /// <summary>
        /// Содержимое формы
        /// </summary>
        string Content { get; set; }
        /// <summary>
        /// Фон формы
        /// </summary>
        Color? Background { get; set; }
        /// <summary>
        /// Папка принадлежности формы, пусто - если форма глобальная
        /// </summary>        
        ICustomFolder Folder { get; }
        /// <summary>
        /// Скрипт, вызываемый при открытии формы
        /// </summary>
        IScript OnOpenScript { get; set; }
        /// <summary>
        /// Скрипт вызываемый при закрытии формы
        /// </summary>
        IScript OnCloseScript { get; set; }
        /// <summary>
        /// Тип формы
        /// </summary>
        CoaFormTypes Type { get; }
        /// <summary>
        /// Сохранение изменений в форме, при ее изменении
        /// </summary>
        void Save();
    }
}
