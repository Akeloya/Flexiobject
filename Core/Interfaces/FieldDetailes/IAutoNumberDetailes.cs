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
namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// User identifier number
    /// <seealso cref="ICustomFolder"/>
    /// <seealso cref="IUserFieldDefinition"/>
    /// </summary>
    public interface IAutoNumberDetailes : IBase
    {
        /// <summary>
        /// Field number width
        /// </summary>
        int FieldWidth { get; set; }
        /// <summary>
        /// Inherit settings from parent folder
        /// </summary>
        bool InheritSettings { get; set; }
        /// <summary>
        /// Fill zeros empty digits
        /// </summary>
        bool FillZeroes { get; set; }
        /// <summary>
        /// Initial number value
        /// </summary>
        int InitialValue { get; set; }
        /// <summary>
        /// Identifier preffix
        /// </summary>
        string Prefix { get; set; }
        /// <summary>
        /// Subfolders will get value from parent folder and won't generate own values
        /// </summary>
        bool ShareNumbersWithSubfolders { get; set; }
        /// <summary>
        /// Identifier suffix
        /// </summary>
        string Suffix { get; set; }
        /// <summary>
        /// Converting string identifier value to number
        /// </summary>
        /// <param name="value">String identifier value</param>
        /// <returns></returns>
        long ToNumber(string value);
    }
}