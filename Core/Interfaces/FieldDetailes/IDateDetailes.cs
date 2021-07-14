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
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Field definition detales for type 'Date'
    /// <seealso cref="IUserFieldDefinition"/>
    /// <seealso cref="CoaFieldTypes"/>
    /// </summary>
    public interface IDateDetailes : IBase
    {
        /// <summary>
        /// Default value of field will be object creation date-time
        /// </summary>
        bool CreationDateAsDefault { get; set; }
        /// <summary>
        /// Current date-time will be value of field
        /// </summary>
        bool CurrentDateTime { get; set; }
        /// <summary>
        /// Only date, time part will be 00:00:00
        /// </summary>
        bool DateOnly { get; set; }
        /// <summary>
        /// Time zone independent
        /// </summary>
        bool TimezoneIndependent { get; set; }
    }
}