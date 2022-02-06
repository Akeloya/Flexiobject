using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Date time field property
    /// </summary>
    [Flags]
    public enum CoaFieldProperties
    {
        /// <summary>
        /// No default value
        /// </summary>
        NoDefaultValue = 0,
        /// <summary>
        /// Only date, whithout time
        /// </summary>
        DateOnly = 1,
        /// <summary>
        /// Default value - curent time
        /// </summary>
        UseCurrentDateTime = 2,
        /// <summary>
        /// Default value - created object time
        /// </summary>
        UseObjectCreationDateTime = 4,
        /// <summary>
        /// Default value - constant
        /// </summary>
        UseDefaultValue = 8,
        /// <summary>
        /// Time will not depend on time zone
        /// </summary>
        TimezoneIndependent = 16
    }
}
