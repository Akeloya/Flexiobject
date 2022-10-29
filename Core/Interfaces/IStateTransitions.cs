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
    /// Транзакция перевода состояния
    /// </summary>
    public interface IStateTransitions : IBase
    {
        /// <summary>
        /// Добавление транзакции в коллекцию
        /// </summary>
        /// <param name="state"></param>
        void Add(IStateTransition state);
        /// <summary>
        /// Создание транзакции перевода
        /// </summary>
        /// <returns></returns>
        IStateTransition CreateStateTransition();
        /// <summary>
        /// Удаление транзакции по идентификатору
        /// </summary>
        /// <param name="idx"></param>
        void Remove(int idx);
        /// <summary>
        /// Удаление указанной транзакции
        /// </summary>
        /// <param name="transition"></param>
        void Remove(IStateTransition transition);
        /// <summary>
        /// Удаление транзакции по ключу
        /// </summary>
        /// <param name="name"></param>
        void RemoveByName(string name);
        /// <summary>
        /// Количество транзакций в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к транзакции по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        IStateTransition this[int idx] { get; }
        /// <summary>
        /// Доступ к транзакции по алиасу
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        IStateTransition this[string alias] { get; }
    }
}