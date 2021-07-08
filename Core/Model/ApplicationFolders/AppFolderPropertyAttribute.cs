/*
 *  "Custom object application core"
 *  An application that implements the ability to customize object templates and actions on them.
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
using System.ComponentModel;

namespace CoaApp.Core
{
    /// <summary>
    /// Application folder field attribute
    /// </summary>
    public class AppFolderPropertyAttribute : Attribute
    {
        private CoaApplicationFoldersProperties _type;
        private bool _required;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Folder bype</param>
        /// <param name="required">Is folder field link required?</param>
        public AppFolderPropertyAttribute(CoaApplicationFoldersProperties type, bool required)
        {
            _type = type;
            _required = required;
        }
        /// <summary>
        /// Folder bype
        /// </summary>
        public CoaApplicationFoldersProperties Type => _type;
        /// <summary>
        /// Required folder field link
        /// </summary>
        public bool Required => _required;
        /// <summary>
        /// Identifier to store state in database
        /// </summary>
        public int Id => (int)_type;
        /// <summary>
        /// Displaing name in UI
        /// </summary>
        public string DisplayName
        {
            get
            {
                var result = string.Empty;
                var enumType = _type.GetType();
                var attributes = enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null)
                    result = attributes[0].ToString();
                return result;
            }
        }
        /// <summary>
        /// Parameter name
        /// </summary>
        public string Name
        {
            get
            {
                return _type.ToString();
            }
        }
    }
}
