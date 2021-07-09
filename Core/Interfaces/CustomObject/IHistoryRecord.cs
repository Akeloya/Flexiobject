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
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// ICustomObject history record
    /// </summary>
    public interface IHistoryRecord : IBase
    {
        /// <summary>
        /// Object modification action
        /// </summary>
        CoaHistoryActionTypes Action { get; }
        /// <summary>
        /// Date-time of modification
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Description text
        /// </summary>
        string Description { get; }
        /// <summary>
        /// New value of data
        /// </summary>
        string NewValue { get; }
        /// <summary>
        /// Old value of data
        /// </summary>
        string OldValue { get; }
        /// <summary>
        /// Workflow state of object if exist field and selected on ICustomFolder
        /// </summary>
        IState State { get; }
        /// <summary>
        /// User modificated object
        /// </summary>
        IUser User { get;}
        /// <summary>
        /// Field which was modificated
        /// </summary>
        IUserFieldDefinition UserField { get; }
        /// <summary>
        /// User name who modificated object
        /// </summary>
        string UserName { get; }
    }
}