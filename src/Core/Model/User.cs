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
using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlexiObject.Core
{
    public abstract class User<T> : AppBase<T>, IUser
    {
        protected User(Application app, T parent) : base(app, parent)
        {

        }
        public bool Active { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICustomFolder DefaultRequestFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Department { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DisplayName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DomainName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGroups Groups => throw new NotImplementedException();
        public IGroups GroupsRecursive => throw new NotImplementedException();
        public bool HasDefaultRequestFolder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LdapProfile { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LoginName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public ICustomObject Object => throw new NotImplementedException();

        public string OutgoingEmailAccount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Phone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool SuperUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int UniqueId => throw new NotImplementedException();

        public CoaUserAuthenticationTypes AuthenticationType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddToGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public bool IsInGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public bool IsInGroupRecursive(string groupName)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
