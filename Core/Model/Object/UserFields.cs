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

namespace CoaApp.Core
{
    public abstract class UserFields : AppBase, IUserFields
    {
        public IUserField this[int idx] => OnGetFieldByIndex(idx);

        public IUserField this[string alias] => OnGetFieldByAlias(alias);

        public int Count => OnGetCount();
        protected UserFields(Application app, object parent) : base(app, parent)
        {

        }
        /// <summary>
        /// Get User fields count
        /// </summary>
        /// <returns></returns>
        protected virtual int OnGetCount()
        {
            return 0;
        }
        /// <summary>
        /// Get User field by index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        protected virtual IUserField OnGetFieldByIndex(int idx)
        {
            return null;
        }
        /// <summary>
        /// Get User field by alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        protected virtual IUserField OnGetFieldByAlias(string alias)
        {
            return null;
        }
    }
}
