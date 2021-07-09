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
using System;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Base user object in application
    /// </summary>
    public interface ICustomObject : IBase, IEquatable<ICustomObject>
    {
        /// <summary>
        /// Unique identifier of object
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Object name from folder naming schema
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Object created date-time
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// Object fields defined in folder
        /// </summary>
        IUserFields UserFields { get; }
        /// <summary>
        /// Object history changes
        /// </summary>
        IHistory History { get; }
        /// <summary>
        /// Save object
        /// </summary>
        void Save(CoaEnumSaveFlags flags);
        /// <summary>
        /// Removing object
        /// </summary>
        /// <param name="skipTrashbin">Skip trash bin. By default object removed in trash bin, and after it's cleared - from database</param>
        /// <param name="ignoreReferences">Ignore references to another objects</param>
        /// <param name="flags">Deletion parameters</param>
        void Delete(bool skipTrashbin = false, bool ignoreReferences = false, CoaDeletionObjectFlags? flags = null);
        /// <summary>
        /// Parent folder, which object belongs to
        /// </summary>
        ICustomFolder CustomObjFolder { get; }
        /// <summary>
        /// Get modified object state
        /// </summary>
        bool IsModified { get; }
    }
}