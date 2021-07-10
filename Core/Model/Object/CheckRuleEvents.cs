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

using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Rule check event args
    /// </summary>
    public class CheckRuleEvents : EventArgs
    {
        /// <summary>
        /// Flag active field
        /// </summary>
        public bool EnableChangeResult { get; set; } = true;
        /// <summary>
        /// Flag field required
        /// </summary>
        public bool RequiredChangeResult { get; set; }
        /// <summary>
        /// Field alias
        /// </summary>
        public string Alias { get; }
        /// <summary>
        /// New value
        /// </summary>
        public object NewValue { get; }
        /// <summary>
        /// Old value
        /// </summary>
        public object OldValue { get; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="alias">Field alias</param>
        /// <param name="objOldValue">Old value</param>
        /// <param name="objNewVal">New value</param>
        public CheckRuleEvents(string alias, object objOldValue, object objNewVal)
        {
            Alias = alias;
            NewValue = objNewVal;
            OldValue = objOldValue;
        }
    }
}
