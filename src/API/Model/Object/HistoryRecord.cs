using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;

using System;

namespace FlexiObject.API.Model.Object
{
    public class HistoryRecord : AppBase, IHistoryRecord
    {
        protected HistoryRecord(Application app, object parent) : base(app, parent)
        {

        }

        protected HistoryRecord(Application app,
                                object parent,
                                int fieldId,
                                FlexiHistoryActionTypes action,
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

        private IUserFieldDefinition _field;
        private IUser _user;
        private IState _state;
        private int _userId;
        private int _fieldId;
        private FlexiHistoryActionTypes _action;
        private DateTime _date;
        private string _description;
        private string _oldValue;
        private string _newValue;

        public FlexiHistoryActionTypes Action => _action;

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
