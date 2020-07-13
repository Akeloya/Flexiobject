/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
    /// Aggregation functions types
    /// </summary>
    public enum CoaEnumAggregateFunctions
    {
        /// <summary>
        /// No function
        /// </summary>
        None,
        /// <summary>
        /// Summ function
        /// </summary>
        Summ,
        /// <summary>
        /// Count function
        /// </summary>
        Count,
        /// <summary>
        /// Average function
        /// </summary>
        Avg,
        /// <summary>
        /// Min function
        /// </summary>
        Min,
        /// <summary>
        /// Max function
        /// </summary>
        Max
    }
}