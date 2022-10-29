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
    /// Вывод объектов в виде дерева
    /// </summary>
    public interface ITreeLayout : IBase
    {
        /// <summary>
        /// Добавление уровня
        /// </summary>
        /// <param name="ufd"></param>
        void AppendLevel(int ufd);
        /// <summary>
        /// Очистка представления
        /// </summary>
        void Clear();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>ID поля</returns>
        int GetLevel(int idx);
    }
}