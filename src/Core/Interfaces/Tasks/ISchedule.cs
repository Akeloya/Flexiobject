using System;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Расписание выполнения заданий
    /// </summary>
    public interface ISchedule : IBase
    {
        /// <summary>
        /// Номер дня
        /// </summary>
        byte DayNumber { get; set; }
        /// <summary>
        /// Смещение в днях
        /// </summary>
        short DayOffset { get; set; }
        /// <summary>
        /// Продолжительность
        /// </summary>
        long Duration { get; set; }
        /// <summary>
        /// Формат продолжительности
        /// </summary>
        FlexiScheduleTimeUnits DurationTimeUnit { get; set; }
        /// <summary>
        /// Активно
        /// </summary>
        bool Enabled { get; set; }
        /// <summary>
        /// Завершить после числа повторений
        /// </summary>
        long EndAfterOccurrences { get; set; }
        /// <summary>
        /// Дата завершения
        /// </summary>
        DateTime EndDate { get; set; }
        /// <summary>
        /// Завершить после даты
        /// </summary>
        DateTime EndOccurrencesByDate { get; set; }
        /// <summary>
        /// Тип завершения
        /// </summary>
        FlexiScheduleEndTypes EndType { get; set; }
        /// <summary>
        /// Задержка
        /// </summary>
        long LeadTime { get; set; }
        /// <summary>
        /// Формат задержки
        /// </summary>
        FlexiScheduleTimeUnits LeadTimeUnit { get; set; }
        /// <summary>
        /// Номер месяца
        /// </summary>
        FlexiScheduleTimeUnits MonthNumber { get; set; }
        /// <summary>
        /// Следующая дата запуска
        /// </summary>
        DateTime NextDate { get; set; }
        /// <summary>
        /// Шаблон под типа
        /// </summary>
        short PatternSubType { get; set; }
        /// <summary>
        /// Количество выполнений
        /// </summary>
        long Occurrences { get; }
        /// <summary>
        /// Схема повторения
        /// </summary>
        short RecurrencePattern { get; set; }
        /// <summary>
        /// Количество повторений
        /// </summary>
        short RepeatNumber { get; set; }
        /// <summary>
        /// Дата начала
        /// </summary>
        DateTime StartDate { get; set; }
        /// <summary>
        /// Номер дня недели
        /// </summary>
        byte WeekdayNumber { get; set; }
        /// <summary>
        /// Повторять каждый день в неделе
        /// </summary>
        byte WeekdayRepetition { get; set; }
        /// <summary>
        /// Будни
        /// </summary>
        byte Weekdays { get; set; }

    }
}