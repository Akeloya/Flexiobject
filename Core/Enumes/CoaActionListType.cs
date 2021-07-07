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
    /// Object modification actions
    /// </summary>
    public enum CoaActionListType
    {
        /// <summary>
        /// Actions will execute befor object will be created in database
        /// </summary>
        BeforeCreation,
        /// <summary>
        /// Actions execute after object created in database
        /// </summary>
        AfterCreation,
        /// <summary>
        /// Actions will execute before object will be modified
        /// </summary>
        BeforeModification,
        /// <summary>
        /// Actions will execute after object will be modified
        /// </summary>
        AfterModification,
        /// <summary>
        /// Actions will execute before object wiil get state deleted
        /// </summary>
        BeforeDeletion,
        /// <summary>
        /// Actions will execute after object will get state deleted
        /// </summary>
        AfterDeletion
    }
}