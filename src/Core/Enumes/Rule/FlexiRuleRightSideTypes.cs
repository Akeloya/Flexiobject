using System;

namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Right side operand type
    /// </summary>
    [Serializable]
    public enum FlexiRuleRightSideTypes
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
        /// DateFime offset
        /// </summary>
        DateTimeOffset
    }
}
