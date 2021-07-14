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

using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaCustomObjects : AppBase, ICustomObjects
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected CoaCustomObjects(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract ICustomObject this[int index] { get; }
        ///<inheritdoc/>
        public abstract ICustomObject this[string name] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        protected internal bool IsModified { get; }
        ///<inheritdoc/>
        public abstract ICustomObject Add();
        ///<inheritdoc/>
        public abstract void AddExisting(ICustomObject obj);
        ///<inheritdoc/>
        public abstract void AddExistingById(long id);
        ///<inheritdoc/>
        public abstract void Delete(long id);
        ///<inheritdoc/>
        public abstract void Remove(ICustomObject obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
        ///<inheritdoc/>
        public abstract void RemoveExisting(object variant);
        ///<inheritdoc/>
        public abstract void RemoveExistingById(long id);
        ///<inheritdoc/>
        public abstract void Restore(long id);
    }
}
