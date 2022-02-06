using System;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Task execution schedule
    /// </summary>
    public interface ISchedule : IBase
    {
        /// <summary>
        /// Day number
        /// </summary>
        byte DayNumber { get; set; }
        /// <summary>
        /// Day offset from first day
        /// </summary>
        short DayOffset { get; set; }
        /// <summary>
        /// Duration
        /// </summary>
        long Duration { get; set; }
        /// <summary>
        /// Duration format type
        /// </summary>
        CoaScheduleTimeUnits DurationTimeUnit { get; set; }
        /// <summary>
        /// Schedule active
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// End after N occurences
        /// </summary>
        long EndAfterOccurrences { get; set; }
        /// <summary>
        /// Disable schedule after this date
        /// </summary>
        DateTime EndDate { get; set; }
        /// <summary>
        /// End execute schedule by this date
        /// </summary>
        DateTime EndOccurrencesByDate { get; set; }
        /// <summary>
        /// Schedule end type
        /// </summary>
        CoaScheduleEndTypes EndType { get; set; }
        /// <summary>
        /// Lead time
        /// </summary>
        long LeadTime { get; set; }
        /// <summary>
        /// Lead time type
        /// </summary>
        CoaScheduleTimeUnits LeadTimeUnit { get; set; }
        /// <summary>
        /// Execute month number
        /// </summary>
        CoaScheduleTimeUnits MonthNumber { get; set; }
        /// <summary>
        /// Next run date
        /// </summary>
        DateTime NextDate { get; set; }
        /// <summary>
        /// Occurrences count
        /// </summary>
        long Occurrences { get; }
        /// <summary>
        /// Recurrence pattern
        /// </summary>
        short RecurrencePattern { get; set; }
        /// <summary>
        /// Repeat number count
        /// </summary>
        short RepeatNumber { get; set; }
        /// <summary>
        /// Schedule start date
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// Weekday number to reccurrence
        /// </summary>
        byte WeekdayNumber { get; set; }
        /// <summary>
        /// Repeat days (bit operation) on week
        /// </summary>
        byte WeekdayRepetition { get; set; }
    }
}