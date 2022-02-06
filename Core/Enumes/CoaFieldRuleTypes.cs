namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Rule type property of field
    /// </summary>
    public enum CoaFieldRuleTypes
    {
        /// <summary>
        /// Rule for prevent null value if field value required
        /// </summary>
        RequiredRule,
        /// <summary>
        /// Rule enable or disable control in UI or block any modification field value
        /// </summary>
        EnabledRule,
        /// <summary>
        /// Rule for restrict link between objects
        /// </summary>
        RestrictionRule
    }
}
