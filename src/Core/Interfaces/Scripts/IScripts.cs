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
using System.Collections.Generic;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция скриптов (модулей кода)
    /// </summary>
    public interface IScripts : IBase
    {
        /// <summary>
        /// Добавление нового скрипта
        /// </summary>
        /// <returns></returns>
        IScript Add();
        /// <summary>
        /// Создание нового скрипта с шаблоном текста согласно указанному типу
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IScript Add(CoaScriptTypes type);
        /// <summary>
        /// Удаление скрипта по его ИД
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);
        /// <summary>
        /// Количество скриптов в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к скрипту по его ИД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IScript this [int id] { get; }
        /// <summary>
        /// Заглушка
        /// </summary>
        List<IScript> List { get; } 
    }
}