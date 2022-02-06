namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Field rule check types
    /// </summary>
    public enum CoaRuleRequeiredCheckTypes
    {
        /// <summary>
        /// Rule will be recalculated only if this field changed
        /// </summary>
        ThisFieldChanged,
        /// <summary>
        /// Rule will be recalculated when any field changed
        /// </summary>
        AnyFieldChanged
    }
}
