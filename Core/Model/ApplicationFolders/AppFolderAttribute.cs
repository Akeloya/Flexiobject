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
using CoaApp.Core.Enumes;
using System.ComponentModel;

namespace CoaApp.Core.Model.ApplicationFolders
{
    /// <summary>
    /// An attribute that specifies for a class its application folder type
    /// </summary>
    public class AppFolderAttribute : Attribute
    {
        private CoaApplicationFolders _type;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Тип папки</param>
        public AppFolderAttribute(CoaApplicationFolders type)
        {
            _type = type;
        }
        /// <summary>
        /// Application folder type
        /// </summary>
        public CoaApplicationFolders Type => _type;
        /// <summary>
        /// Identity for store in database
        /// </summary>
        public int Id => (int)_type;
        /// <summary>
        /// Displan name in UI
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
    }
}
