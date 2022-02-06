using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Right side operand type
    /// </summary>
    [Serializable]
    public enum CoaRuleRightSideTypes
    {
        /// <summary>
        /// Right side is constant
        /// </summary>
        Constant,
        /// <summary>
        /// Value for right side will asked from user
        /// </summary>
        AskUser,
        /// <summary>
        /// Relative offset
        /// </summary>
        RelativeDateTime
    }
}
