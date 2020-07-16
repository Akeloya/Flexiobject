/*
 *  "Custom object application core"
 *  An application that implements the ability to customize object templates and actions on them.
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
    /// Left side operand type
    /// </summary>
    [Serializable]
    public enum CoaRuleLeftSideType
    {
        /// <summary>
        /// Left side is field path
        /// </summary>
        FieldPath,
        /// <summary>
        /// Left side is object unique id
        /// </summary>
        UniqueId,
        /// <summary>
        /// Left side is current user
        /// </summary>
        CurrentUser,
        /// <summary>
        /// Left side is client type
        /// </summary>
        CurrentClient,
        /// <summary>
        /// Left side is context compare object
        /// </summary>
        Context,
        /// <summary>
        /// Left side is named rule
        /// </summary>
        CoaLeftSideNamedRule,
        /// <summary>
        /// Left side is folder
        /// </summary>
        Folder,
        /// <summary>
        /// Left side is folder alias
        /// </summary>
        FolderAliasName,
        /// <summary>
        /// Left side is folder name
        /// </summary>
        FolderName,
        /// <summary>
        /// Left side is items count
        /// </summary>
        Count
    }
}
