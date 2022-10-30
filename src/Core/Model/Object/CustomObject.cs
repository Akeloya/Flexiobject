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

using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;

namespace FlexiObject.Core
{
    public class CustomObject<T> : AppBase<T>, ICustomObject
    {
        protected CustomObject(Application app, T parent) : base(app, parent)
        {

        }

        public long UniqueId => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public IUserFields UserFields => throw new System.NotImplementedException();

        public IHistory History => throw new System.NotImplementedException();

        public ICustomFolder RequestFolder => throw new System.NotImplementedException();

        public bool IsModified => throw new System.NotImplementedException();

        public void Delete(bool skipTrashbin = false, bool ignoreReferences = false, CoaDeletionObjectFlags? flags = null)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
