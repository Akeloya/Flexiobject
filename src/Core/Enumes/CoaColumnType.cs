/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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

namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Column display types
    /// </summary>
    public enum CoaColumnType
    {
        /// <summary>
        /// Symbol column
        /// </summary>
        Symbol,
        /// <summary>
        /// Attachments column
        /// </summary>
        Attachments,
        /// <summary>
        /// Folder column displaying the folder name of the object
        /// </summary>
        Folder,
        /// <summary>
        /// Field column displaying the value of a field of the object
        /// </summary>
        Field,
        /// <summary>
        /// Name column displaying the object name of the object
        /// </summary>
        Name,
        /// <summary>
        /// Folder Path column displaying the complete path to the folder of the object
        /// </summary>
        FolderPath,
    }
}
