namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Collection relative date time types for filters
    /// </summary>
    public enum CoaRuleRelativeDateTypes
    {
        /// <summary>
        /// compare with the current time
        /// </summary>
        CurrentTime = 1,
        /// <summary>
        /// compare with the start of the current day
        /// </summary>
        StartCurrentDay = 2,
        /// <summary>
        /// compare with the start of the current week
        /// </summary>
        StartCurrentWeek = 3,
        /// <summary>
        /// compare with the start of the current month
        /// </summary>
        StartCurrentMonth = 4,
        /// <summary>
        /// compare with the start of the current year
        /// </summary>
        StartCurrentYear = 5,
        /// <summary>
        /// compare with the start of the previous month
        /// </summary>
        StartPreviousMonth = 6,
        /// <summary>
        /// compare with the start of the previous year
        /// </summary>
        StartPreviousYear = 7,
        /// <summary>
        /// compare with the start of the next month
        /// </summary>
        StartNextMonth = 8,
        /// <summary>
        /// compare with the start of the next year
        /// </summary>
        StartNextYear = 9
    }
}
