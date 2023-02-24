/*
 *  "Flexiobject core"
 *  An application that implements the ability to customize object templates and actions on them.
 *  Copyright (C) 2019 by Maxim V. Yugov.
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
using FlexiObject.Core.Interfaces;
using System;

namespace FlexiObject.Core
{
    public abstract class Users: AppBase, IUsers
    {
        protected Users(Application app, object parent) : base(app, parent)
        {

        }
        public IUser this[int index] => throw new NotImplementedException();

        public IUser this[string name] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IUser Add()
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByLoginName(string login)
        {
            throw new NotImplementedException();
        }

        public void Remove(IUser obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
