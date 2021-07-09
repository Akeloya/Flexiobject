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

namespace CoaApp.Core.Object
{
    public abstract class HistoryRecord : AppBase, IHistoryRecord
    {
        private IUserFieldDefinition _field;
        private IUser _user;
        private readonly IState _state;
        private readonly int _userId;
        private readonly int _fieldId;
        private readonly CoaHistoryActionTypes _action;
        private readonly DateTime _date;
        private readonly string _description;
        private readonly string _oldValue;
        private readonly string _newValue;
        protected HistoryRecord(IApplication app, object parent) : base(app, parent)
        {

        }

        protected HistoryRecord(IApplication app, 
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
            _date = date;
            _action = action;
            _description = desc;
            _oldValue = oldVal;
            _newValue = newVal;
            _state = state;
            _userId = userId;
        }
        public CoaHistoryActionTypes Action => _action;
        public DateTime Date => _date;
        public string Description => _description;
        public string NewValue => _newValue;
        public string OldValue => _oldValue;
        public IState State => _state;
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

        public string UserName => throw new NotImplementedException();

        protected abstract IUserFieldDefinition OnGetField(int fieldId);
        protected abstract IUser OnGetUser(int userId);
    }
}
