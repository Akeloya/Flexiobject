/*
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

using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core.Object
{
    public class HistoryRecord : AppBase, IHistoryRecord
    {
        private IUserFieldDefinition _field;
        private IUser _user;
        private int _userId;
        private int _fieldId;

        public CoaHistoryActionTypes Action { get; }

        public DateTime Date { get; }

        public string Description { get; }

        public string NewValue { get; }

        public string OldValue { get; }

        public IState State { get; }

        public IUser User
        {
            get
            {
                if (_user == null)
                    _user = OnGetUser(_userId);
                return _user;
            }
        }

        public IUserFieldDefinition UserField
        {
            get
            {
                if (_field == null)
                    _field = OnGetField(_fieldId);
                return _field;
            }
        }

        public string UserName => User?.Name;
        protected HistoryRecord(Application app, History parent) : base(app, parent)
        {

        }

        protected HistoryRecord(Application app, 
                                object parent,
                                int fieldId,
                                CoaHistoryActionTypes action,
                                DateTime date,
                                string desc,
                                string oldVal,
                                string newVal,
                                int userId,
                                IState state) : base(app, parent)
        {
            _fieldId = fieldId;
            Date = date;
            Action = action;
            Description = desc;
            OldValue = oldVal;
            NewValue = newVal;
            State = state;
            _userId = userId;
        }
        protected virtual IUserFieldDefinition OnGetField(int fieldId)
        {
            throw new NotImplementedException();
        }

        protected virtual IUser OnGetUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
