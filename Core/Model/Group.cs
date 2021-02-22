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
using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    public abstract class Group : AppBase, IGroup
    {
        protected Group(Application app, object parent) : base(app, parent)
        {

        }
        public int UniqueId => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string DisplayName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EmailAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CoaGroupBehaviorTypes EmailBehavior { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IGroups Groups => throw new NotImplementedException();

        public IGroups GroupsRecursive => throw new NotImplementedException();

        public ICustomObject Object => throw new NotImplementedException();

        public IUsers Users => throw new NotImplementedException();

        public IUsers UsersRecurcive => throw new NotImplementedException();

        public void AddGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void AddUser(IUser user)
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

        public void RemoveGroup(IGroup group)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(IUser user)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SendEmail()
        {
            throw new NotImplementedException();
        }
    }
}
