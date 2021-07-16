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
            { CoaRuleComparisonsTypes.GreaterThanOptionListText, Resource.CoaRuleComparisonsTypesGreaterThanOptionListText },
            { CoaRuleComparisonsTypes.GreaterThanOrEqual, Resource.CoaRuleComparisonsTypesGreaterThanOrEqual },
            { CoaRuleComparisonsTypes.GreaterThanOrEqualOptionListText, Resource.CoaRuleComparisonsTypesGreaterThanOrEqualOptionListText },
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
            { CoaRuleComparisonsTypes.LessThanOptionListText, Resource.CoaRuleComparisonsTypesLessThanOptionListText },
            { CoaRuleComparisonsTypes.LessThanOrEqual, Resource.CoaRuleComparisonsTypesLessThanOrEqual },
            { CoaRuleComparisonsTypes.LessThanOrEqualOptionListText, Resource.CoaRuleComparisonsTypesLessThanOptionListText },
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
