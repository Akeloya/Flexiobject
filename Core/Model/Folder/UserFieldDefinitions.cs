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
    public abstract class UserFieldDefinitions: AppBase, IUserFieldDefinitions
    {
        protected UserFieldDefinitions(IApplication app, object parent, bool isContainer = false): base(app, parent)
        {
            IsContainer = isContainer;
        }
        public bool IsContainer { get; }
        public abstract IUserFieldDefinition this[int index] { get; }
        public abstract IUserFieldDefinition this[string name] { get; }
        public abstract int Count { get; }
        public abstract IUserFieldDefinition Add(CoaFieldTypes type);
        public abstract IUserFieldDefinition Add();
        public abstract void AddExisting(IUserFieldDefinition field);
        public abstract void Remove(IUserFieldDefinition obj);
        public abstract void Remove(int index);
        public abstract void RemoveExisting(IUserFieldDefinition field);
    }
}
