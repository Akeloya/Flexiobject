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

namespace Flexiobject.Core.Interfaces
{
    /// <summary>
    /// Form collection
    /// </summary>
    public interface IForms : IBase
    {
        /// <summary>
        /// Add new form
        /// </summary>
        /// <returns>New IForm object </returns>
        IForm Add();
        /// <summary>
        /// Form count in collection
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Index access form collection
        /// </summary>
        /// <param name="idx">Index 0...Count-1</param>
        /// <returns></returns>
        IForm this[int idx] { get; }
        /// <summary>
        /// Access to object in collection by name
        /// </summary>
        /// <param name="name">Form name</param>
        /// <returns></returns>
        IForm this[string name] { get; }
    }
}
