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
using System.Collections.Generic;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Определение коллекции состояний рабочего процесса
    /// </summary>
    public interface IStateDefinitions : IBase
    {
        /// <summary>
        /// Создать состояние
        /// </summary>
        /// <returns>Новое состояние не привязанное к коллекции</returns>
        IState CreateStateDefinition();
        /// <summary>
        /// Добавить созданное состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        void Add(IState state);
        /// <summary>
        /// Начальное состояние
        /// </summary>
        IState InitialState { get; }
        /// <summary>
        /// Удалить состояние по индексу
        /// </summary>
        /// <param name="idx"></param>
        void Remove(int idx);
        /// <summary>
        /// Удалить состояние
        /// </summary>
        /// <param name="state">Состояние в коллекции, которое требуется удалить</param>
        void Remove(IState state);
        /// <summary>
        /// Доступ к коллекции состояний по индексу
        /// </summary>
        /// <param name="idx">Индекс 0..Count-1 коллекции состояний</param>
        /// <returns>IState объект коллекции</returns>
        IState this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции состояний по алиасу
        /// </summary>
        /// <param name="alias">Алиас состояния из коллекции</param>
        /// <returns>IState объект коллекции</returns>
        IState this[string alias] { get; }
        /// <summary>
        /// Количество состояий в коллекции
        /// </summary>
        int Count { get; }
    }
}