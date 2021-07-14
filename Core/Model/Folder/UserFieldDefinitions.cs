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
using CoaApp.Core.Interfaces;

namespace CoaApp.Core.Folder
{
    ///<inheritdoc/>
    public abstract class UserFieldDefinitions: AppBase, IUserFieldDefinitions
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="isContainer">Flag only for collection, wich belong to parent folder in app</param>
        protected UserFieldDefinitions(IApplication app, object parent, bool isContainer = false): base(app, parent)
        {
            IsContainer = isContainer;
        }
        ///<inheritdoc/>
        public bool IsContainer { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition this[int index] { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition this[string name] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition Add(CoaFieldTypes type);
        ///<inheritdoc/>
        public abstract IUserFieldDefinition Add();
        ///<inheritdoc/>
        public abstract void AddExisting(IUserFieldDefinition field);
        ///<inheritdoc/>
        public abstract void Remove(IUserFieldDefinition obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
        ///<inheritdoc/>
        public abstract void RemoveExisting(IUserFieldDefinition field);
    }
}
