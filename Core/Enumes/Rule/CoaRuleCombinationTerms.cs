using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Boolean combination rule operators
    /// </summary>
    [Serializable]
    public enum CoaRuleCombinationTerms
    {
        /// <summary>
        /// Calculate boolean expression operator
        /// </summary>        
        Term = 1,
        /// <summary>
        /// Logical operator "And"
        /// </summary>        
        And = 2,
        /// <summary>
        /// Logical operator "Or"
        /// </summary>        
        Or = 3
    }
}
