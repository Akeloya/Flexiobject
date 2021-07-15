/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
 *
 *  This program is free software, you can redistribute it and/or modify
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
 *  along with this program.  If not, see <http,//www.gnu.org/licenses/>.
 */
using CoaApp.Core.Enumes;
using CoaApp.Core.Properties;
using System.Collections.Generic;

namespace CoaApp.Core.Model.Rule
{
    /// <summary>
    /// Rule helpers to get string value of condition elements
    /// </summary>
    public static class RuleHelpers
    {
        private static readonly Dictionary<CoaRuleComparisonsTypes, string> _comparisonStr = new()
        {
            { CoaRuleComparisonsTypes.BelongsToGroup, Resource.CoaRuleComparisonsTypesBelongsToGroup },
            { CoaRuleComparisonsTypes.ContainsCurrentUser, Resource.CoaRuleComparisonsTypesContainsCurrentUser },
            { CoaRuleComparisonsTypes.ContainsUser, Resource.CoaRuleComparisonsTypesContainsUser },
            { CoaRuleComparisonsTypes.DoesNotBelongToGroup, Resource.CoaRuleComparisonsTypesBelongsToGroup },
            { CoaRuleComparisonsTypes.DoesNotContainCurrentUser, Resource.CoaRuleComparisonsTypesContainsCurrentUser },
            { CoaRuleComparisonsTypes.DoesNotMatch, Resource.CoaRuleComparisonsTypesDoesNotMatch },
            { CoaRuleComparisonsTypes.GreaterThan, Resource.CoaRuleComparisonsTypesGreaterThan },
            { CoaRuleComparisonsTypes.GreaterThanDropDownText, Resource.CoaRuleComparisonsTypesGreaterThanDropDownText },
            { CoaRuleComparisonsTypes.GreaterThanOrEqual, Resource.CoaRuleComparisonsTypesGreaterThanOrEqual },
            { CoaRuleComparisonsTypes.GreaterThanOrEqualDropDownText, Resource.CoaRuleComparisonsTypesGreaterThanOrEqualDropDownText },
            { CoaRuleComparisonsTypes.Is, Resource.CoaRuleComparisonsTypesIs },
            { CoaRuleComparisonsTypes.IsBackgroundProcess, Resource.CoaRuleComparisonsTypesIsBackgroundProcess },
            { CoaRuleComparisonsTypes.IsGroup, Resource.CoaRuleComparisonsTypesIsGroup },
            { CoaRuleComparisonsTypes.IsInitialState, Resource.CoaRuleComparisonsTypesIsInitialState },
            { CoaRuleComparisonsTypes.IsInternalUser, Resource.CoaRuleComparisonsTypesIsInternalUser },
            { CoaRuleComparisonsTypes.IsMemberOf, Resource.CoaRuleComparisonsTypesIsNotMemberOf },
            { CoaRuleComparisonsTypes.IsNot, Resource.CoaRuleComparisonsTypesIsNot },
            { CoaRuleComparisonsTypes.IsNotInitialState, Resource.CoaRuleComparisonsTypesIsNotInitialState },
            { CoaRuleComparisonsTypes.IsNotInternalUser, Resource.CoaRuleComparisonsTypesIsNotInternalUser },
            { CoaRuleComparisonsTypes.IsNotMemberOf, Resource.CoaRuleComparisonsTypesIsNotMemberOf },
            { CoaRuleComparisonsTypes.IsSuperuser, Resource.CoaRuleComparisonsTypesIsSuperuser },
            { CoaRuleComparisonsTypes.IsUser, Resource.CoaRuleComparisonsTypesIsUser },
            { CoaRuleComparisonsTypes.IsVisibleForCurrentUser, Resource.CoaRuleComparisonsTypesIsVisibleForCurrentUser },
            { CoaRuleComparisonsTypes.LessThan, Resource.CoaRuleComparisonsTypesLessThan },
            { CoaRuleComparisonsTypes.LessThanDropDownText, Resource.CoaRuleComparisonsTypesLessThanDropDownText },
            { CoaRuleComparisonsTypes.LessThanOrEqual, Resource.CoaRuleComparisonsTypesLessThanOrEqual },
            { CoaRuleComparisonsTypes.LessThanOrEqualDropDownText, Resource.CoaRuleComparisonsTypesLessThanDropDownText },
            { CoaRuleComparisonsTypes.Matches, Resource.CoaRuleComparisonsTypesMatches },
            { CoaRuleComparisonsTypes.EqualTo, Resource.CoaRuleComparisonsTypesEqualTo },
            { CoaRuleComparisonsTypes.NotEqualTo, Resource.CoaRuleComparisonsTypesNotEqualTo },
            { CoaRuleComparisonsTypes.Contains, Resource.CoaRuleComparisonsTypesContains },
            { CoaRuleComparisonsTypes.NotContains, Resource.CoaRuleComparisonsTypesNotContains },
            { CoaRuleComparisonsTypes.IsUserClient, Resource.CoaRuleComparisonsTypesIs },
            { CoaRuleComparisonsTypes.IsApiInterface, Resource.CoaRuleComparisonsTypesIsApiInterface },
            { CoaRuleComparisonsTypes.NotContainsUser, Resource.CoaRuleComparisonsTypesNotContains }
        };
        /// <summary>
        /// Get string value of comparisson
        /// </summary>
        /// <param name="type">Comparison</param>
        /// <returns>Epmty string or string value of comparison</returns>
        public static string ToStringValue(this CoaRuleComparisonsTypes? type)
        {
            if (type == null)
                return string.Empty;
            if(!_comparisonStr.TryGetValue(type.Value, out string result))
                return string.Empty;
            return result;
        }
        /// <summary>
        /// Get string value of combinations
        /// </summary>
        /// <param name="combination">Combination</param>
        /// <returns>Empty string or string value of combination</returns>
        public static string ToStringValue(this CoaRuleCombinationTerms combination)
        {
            switch (combination)
            {
                case CoaRuleCombinationTerms.And:
                    return Resource.CoaRuleCombinationTermsAnd;
                case CoaRuleCombinationTerms.Or:
                    return Resource.CoaRuleCombinationTermsOr;
                default:
                    return string.Empty;
            }
            
        }
    }
}
