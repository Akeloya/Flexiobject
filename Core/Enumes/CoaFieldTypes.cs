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
    /// Folder field types
    /// </summary>
    public enum CoaFieldTypes : byte
    {
        /// <summary>
        /// Integer value 4 bytes
        /// </summary>
        Int,
        /// <summary>
        /// Short integer 2 bytes
        /// </summary>
        ShortInt,
        /// <summary>
        /// Long integer 8 bytes
        /// </summary>
        Bigint,
        /// <summary>
        /// Decimal field
        /// </summary>
        Decimal,
        /// <summary>
        /// User string(long) identifier field of object
        /// </summary>
        Identifier,
        /// <summary>
        /// Boolean value (true/false)
        /// </summary>
        Boolean,
        /// <summary>
        /// String field with max length 255 bytes
        /// </summary>
        String,
        /// <summary>
        /// Text field to store text with any length
        /// </summary>
        Text,
        /// <summary>
        /// Date time field
        /// </summary>
        Date,
        /// <summary>
        /// Currency field with sign
        /// </summary>
        Currency,
        /// <summary>
        /// List options to select. Allowed single selection
        /// </summary>
        OptionList,
        /// <summary>
        /// Reference to object
        /// </summary>
        Object,
        /// <summary>
        /// Object list 
        /// </summary>
        ObjectList,
        /// <summary>
        /// Field with states and transitions
        /// </summary>
        Workflow
    }
}
