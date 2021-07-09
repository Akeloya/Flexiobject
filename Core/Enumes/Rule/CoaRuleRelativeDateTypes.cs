/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2018 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
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
