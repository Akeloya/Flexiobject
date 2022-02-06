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