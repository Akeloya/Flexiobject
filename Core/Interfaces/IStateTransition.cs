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
    /// Транзакция перевода из состояния в состояние
    /// </summary>
    public interface IStateTransition : IBase
    {
        /// <summary>
        /// Состояние откуда
        /// </summary>
        IState From { get; set; }
        /// <summary>
        /// Состояние куда
        /// </summary>
        IState To { get; set; }
        /// <summary>
        /// Требуемые поля для заполнения
        /// </summary>
        IUserFieldDefinitions RequiredFields { get; set; }
        /// <summary>
        /// Действия, выполняемые до перевода
        /// </summary>
        IActions ActionListBefore { get; }
        /// <summary>
        /// Действия выполняемые после перевода
        /// </summary>
        IActions ActionListAfter { get; }
        /// <summary>
        /// Проверка правила  для объекта
        /// </summary>
        /// <param name="oldRequest">Копия объекта до изменения</param>
        /// <param name="newRequest">Копия объекта после изменения</param>
        /// <returns></returns>
        bool CheckRule(ICustomObject oldRequest, ICustomObject newRequest);
    }
}