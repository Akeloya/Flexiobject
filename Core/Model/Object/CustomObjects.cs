/*
 *  "Custom object application core"
 *  An application that implements the ability to customize object templates and actions on them.
 *  Copyright (C) 2019 by Maxim V. Yugov.
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
    public abstract class CustomObjects<T> : AppBase<T>, ICustomObjects
    {
        protected CustomObjects(Application app, T parent) : base(app, parent)
        {

        }

        public ICustomObject this[int index] => throw new System.NotImplementedException();

        public ICustomObject this[string name] => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public ICustomObject Add()
        {
            throw new System.NotImplementedException();
        }

        public void AddExisting(ICustomObject request)
        {
            throw new System.NotImplementedException();
        }

        public void AddExistingById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ICustomObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveExisting(object variant)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveExistingById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Restore(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
