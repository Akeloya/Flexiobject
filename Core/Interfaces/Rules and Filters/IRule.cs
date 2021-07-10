/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
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
using System.Collections.Generic;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Object filtering rule interface
    /// </summary>
    public interface IRule : IBase
    {
        /// <summary>
        /// КComparisons types
        /// </summary>
        CoaRuleComparisonsTypes? CombinationOperator { get; set; }
        /// <summary>
        /// xml view of rule
        /// </summary>
        string Data { get; set; }
        /// <summary>
        /// Nested rules
        /// </summary>
        IList<IRule> ChiledRules { get; }
        /// <summary>
        /// Boolean combination for current rule or atomic comparison of values
        /// </summary>
        CoaRuleCombinationTerms Combination { get; set; }
        /// <summary>
        /// Type of right side value
        /// </summary>
        CoaRuleRightSideTypes RightSideType { get; set; }
        /// <summary>
        /// Type of left side value
        /// </summary>
        CoaRuleLeftSideTypes LeftSideType { get; set; }
        /// <summary>
        /// Field path
        /// </summary>
        string LeftSideFieldPath { get; set; }
        /// <summary>
        /// Right operand
        /// </summary>
        object RightSideValue { get; set; }
        /// <summary>
        /// Left operand
        /// </summary>
        object LeftSideValue { get; set; }
        /// <summary>
        /// Clear rule and nested rules
        /// </summary>
        void Clear();
        /// <summary>
        /// Calculating rule
        /// </summary>
        /// <param name="request">Object calculating rule for</param>
        /// <returns>Calculating result</returns>
        bool Calculate(ICustomObject request);
        /// <summary>
        /// Field collection affected in current rule
        /// </summary>
        IUserFieldDefinitions AffectedFields { get; }
    }
}