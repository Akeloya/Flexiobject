using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core.Object
{
    ///<inheritdoc/>
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
        /// <summary>
        /// Default constructor for history record
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="fieldId"></param>
        /// <param name="action"></param>
        /// <param name="date"></param>
        /// <param name="desc"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        /// <param name="userId"></param>
        /// <param name="state"></param>
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
        ///<inheritdoc/>
        public CoaHistoryActionTypes Action => _action;
        ///<inheritdoc/>
        public DateTime Date => _date;
        ///<inheritdoc/>
        public string Description => _description;
        ///<inheritdoc/>
        public string NewValue => _newValue;
        ///<inheritdoc/>
        public string OldValue => _oldValue;
        ///<inheritdoc/>
        public IState State => _state;
        ///<inheritdoc/>
        public IUser User
        {
            get
            {
                if (_user == null)
                    _user = OnGetUser(_userId);
                return _user;
            }
        }
        ///<inheritdoc/>
        public IUserFieldDefinition UserField
        {
            get
            {
                if (_field == null)
                    _field = OnGetField(_fieldId);
                return _field;
            }
        }
        ///<inheritdoc/>
        public string UserName => User?.Name;
        ///<inheritdoc/>
        protected abstract IUserFieldDefinition OnGetField(int fieldId);
        ///<inheritdoc/>
        protected abstract IUser OnGetUser(int userId);
    }
}
