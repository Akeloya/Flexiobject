/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using Flexiobject.Core.Enumes;

namespace Flexiobject.Core.Interfaces
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
        CoaScheduleTimeUnits DurationTimeUnit { get; set; }
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
        CoaScheduleEndTypes EndType { get; set; }
        /// <summary>
        /// Задержка
        /// </summary>
        long LeadTime { get; set; }
        /// <summary>
        /// Формат задержки
        /// </summary>
        CoaScheduleTimeUnits LeadTimeUnit { get; set; }
        /// <summary>
        /// Номер месяца
        /// </summary>
        CoaScheduleTimeUnits MonthNumber { get; set; }
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