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

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// ICustomObject save flags
    /// </summary>
    [Flags]
    public enum CoaEnumSaveFlags
    {
        /// <summary>
        /// No saving flags - default value
        /// </summary>
        NoFlags = 0,
        /// <summary>
        /// Don't check permissions
        /// </summary>
        DoNotCheckPermission = 1,
        /// <summary>
        /// Don't check data:
        /// - Regular expressions
        /// - Restriction filters
        /// - Non defined or incorrect workflow state
        /// - Correct placement of related objects
        /// - Autonumeration corrected
        /// - Empty required fields
        /// </summary>
        DoNotValidateInput = 2,
        /// <summary>
        /// Don't execute actions on folder
        /// </summary>
        DoNotExecuteActions = 4,
        /// <summary>
        /// Don't write any history changes
        /// </summary>
        DoNotUpdateHistory = 8,
        /// <summary>
        /// Don't recalculate autocalculations
        /// </summary>
        DoNotRecalcAutocalculations = 16,
        /// <summary>
        /// Don't check permissions
        /// </summary>
        DoNotCheckPrivileges = 32,
        /// <summary>
        /// Don't check last changed fields
        /// </summary>
        DoNotChangeLastChangeFields = 64
    }
}
