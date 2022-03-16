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
using System.Collections.Generic;

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс правила фильтрования объектов
    /// </summary>
    public interface IRule : IBase
    {
        /// <summary>
        /// Комбинирование правил
        /// </summary>
        CoaRuleComparisonsTypes? CombinationOperator { get; set; }
        /// <summary>
        /// Xml представление правила
        /// </summary>
        string Data { get; set; }
        /// <summary>
        /// Ссылка на дочерние правила
        /// </summary>
        List<IRule> ChiledRules { get; }
        /// <summary>
        /// Логическая комбинация для текущего правила или атомарное сравнение значений
        /// </summary>
        CoaRuleCombinationTerms Combination { get; set; }
        /// <summary>
        /// Тип правого операнда
        /// </summary>
        CoaRuleRightSideTypes RightSideType { get; set; }
        /// <summary>
        /// Тип левого операнда
        /// </summary>
        CoaRuleLeftSideTypes LeftSideType { get; set; }
        /// <summary>
        /// Путь к полю
        /// </summary>
        string LeftSideFieldPath { get; set; }
        /// <summary>
        /// Правый операнд
        /// </summary>
        object RightSideValue { get; set; }
        /// <summary>
        /// Левый операнд
        /// </summary>
        object LeftSideValue { get; set; }
        /// <summary>
        /// Очистка правила
        /// </summary>
        void Clear();
        /// <summary>
        /// Вычисление правила
        /// </summary>
        /// <param name="request">Объект для которого вычисляется правило</param>
        /// <returns>Результат вычисления</returns>
        bool Calculate(ICustomObject request);
        /// <summary>
        /// Коллекция полей, задействованных в текущем правиле
        /// </summary>
        IUserFieldDefinitions AffectedFields { get; }
    }
}