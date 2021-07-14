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
    /// Script types
    /// </summary>
    public enum CoaScriptTypes
    {
        /// <summary>
        /// Definition code
        /// </summary>
        Include,
        /// <summary>
        /// Normal code for executing in folder
        /// </summary>
        Normal,
        /// <summary>
        /// Code for filters
        /// </summary>
        Filter,
        /// <summary>
        /// Code for automatic calculations
        /// </summary>
        Autocalculation,
        /// <summary>
        /// Code for executing in scheduled tascks
        /// </summary>
        ScheduledTask,
        /// <summary>
        /// Code for executin on forms
        /// </summary>
        Form
    }
}