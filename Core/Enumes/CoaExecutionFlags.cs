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
using System;

namespace CoaApp.Core.Enumes
{
    /// <summary>
    /// Execution flags
    /// </summary>
    [Flags]
    public enum CoaExecutionFlags : byte
    {
        /// <summary>
        /// Do not check permissions
        /// </summary>
        DoNotCheckPermissions = 1,
        /// <summary>
        /// Do not check privileges
        /// </summary>
        DoNotCheckPrivileges,
        /// <summary>
        /// Do not validate imput data
        /// </summary>
        DoNotValidateInput,
        /// <summary>
        /// Do not checks identity fields
        /// </summary>
        DoNotCheckForIdentityFields,
        /// <summary>
        /// Do not execute any actions
        /// </summary>
        DoNotExecuteActions,
        /// <summary>
        /// Do not recalculate escalation datetimes
        /// </summary>
        DoNotRecalculateEscalationTimes,
        /// <summary>
        /// Do not create history entries
        /// </summary>
        DoNotCreateHistoryEntries,
        /// <summary>
        /// Do not update any autocalculation on folder for object
        /// </summary>
        DoNotUpdateAutocalculations
    }
}