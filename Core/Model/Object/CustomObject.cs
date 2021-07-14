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
using System;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaCustomObject : AppBase, ICustomObject
    {
        private long _uniqueId;
        private CoaEnumSaveFlags _flags;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="uniqueId"></param>
        protected CoaCustomObject(IApplication app, object parent, long uniqueId = 0) : base(app, parent)
        {
            _uniqueId = uniqueId;
        }
        public static bool operator ==(CoaCustomObject left, ICustomObject right)
        {
            return (left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        public static bool operator !=(CoaCustomObject left, ICustomObject right)
        {
            return !(left?.Equals(right) ?? (right?.Equals(left) ?? true));
        }
        ///<inheritdoc/>
        public long UniqueId => _uniqueId;
        ///<inheritdoc/>
        public abstract string Name {get;}
        ///<inheritdoc/>
        public abstract IUserFields UserFields { get; }
        ///<inheritdoc/>
        public IHistory History => GetHistory(_uniqueId);
        ///<inheritdoc/>
        public abstract ICustomFolder CustomObjFolder { get; }
        ///<inheritdoc/>
        public abstract bool IsModified { get; }
        ///<inheritdoc/>
        protected internal CoaEnumSaveFlags SavingFlags => _flags;
        ///<inheritdoc/>
        public abstract DateTime Created { get; }
        ///<inheritdoc/>
        public void Save(CoaEnumSaveFlags flags = CoaEnumSaveFlags.NoFlags)
        {
            _flags = flags;
            _uniqueId = OnSave();
            _flags = CoaEnumSaveFlags.NoFlags;
        }
        ///<inheritdoc/>
        public bool Equals(ICustomObject other)
        {
            return UniqueId == other.UniqueId;
        }
        ///<inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as ICustomObject);
        }
        ///<inheritdoc/>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        ///<inheritdoc/>
        public abstract void Delete(bool skipTrashbin = false, bool ignoreReferences = false, CoaDeletionObjectFlags? flags = null);
        /// <summary>
        /// On save method declaration
        /// </summary>
        /// <returns>Returns object Id</returns>
        protected abstract long OnSave();
        /// <summary>
        /// Get object history method declarationd
        /// </summary>
        /// <param name="uniqueId">Object Id</param>
        /// <returns>Object history</returns>
        protected abstract IHistory GetHistory(long uniqueId);
    }
}
