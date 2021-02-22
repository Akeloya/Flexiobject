﻿/*
 *  "Custom object application core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
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
using System.ComponentModel;

namespace CoaApp.Core.Object
{
    public abstract class UserField : AppBase, IUserField
    {
        protected UserField(Application app, object parent) : base (app, parent)
        {

        }

        public string this[string columnName] => throw new System.NotImplementedException();

        public dynamic TValue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IUserFieldDefinition Definition => throw new System.NotImplementedException();

        public bool IsNull => throw new System.NotImplementedException();

        public bool IsEnabled => throw new System.NotImplementedException();

        public bool IsRequired => throw new System.NotImplementedException();

        public string Error => throw new System.NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
    } 
}
