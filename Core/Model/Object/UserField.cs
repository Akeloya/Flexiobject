using CoaApp.Core.Enumes;
using CoaApp.Core.Exceptions;
using CoaApp.Core.Exceptions.CommonExceptions;
using CoaApp.Core.Interfaces;
using CoaApp.Core.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CoaApp.Core.Object
{
    ///<inheritdoc/>
    public abstract class UserField : AppBase, IUserField
    {
        private long? _longValue;
        private DateTime? _datetimeValue;
        private decimal? _decimalValue;
        private int? _intlValue;
        private CoaCustomObject _custObjValue;
        private CoaCustomObjects _custObjtListValue;
        private string _stringValue;
        private short? _shortValue;
        private bool? _boolValue;
        private IState _stateValue;
        private IOptionListValue _ddlValue;
        private dynamic _tValueInitiated;

        private readonly IUserFieldDefinition _definition;
        private readonly ICustomObject _custObjParent;
        private bool _initiated;
        private bool _isRequired;
        private bool _isEnabled;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="definition"></param>
        /// <param name="custObj"></param>
        protected UserField(IApplication app, object parent, IUserFieldDefinition definition, ICustomObject custObj) : base (app, parent)
        {
            _custObjParent = custObj;
            _definition = definition;
        }
        ///<inheritdoc/>
        public string this[string columnName] => Validate(columnName);
        ///<inheritdoc/>
        public dynamic TValue
        {
            get
            {
                return GetValueFromValues();
            }
            set
            {
                var oldValue = GetValueFromValues();
                if (_definition.Type == CoaFieldTypes.Object || _definition.Type == CoaFieldTypes.ObjectList)
                    _initiated = false;
                if (value == null && _definition.Type != CoaFieldTypes.Workflow && _definition.Type != CoaFieldTypes.ObjectList)
                {
                    SetValueToValues(null);
                    if (oldValue != GetValueFromValues())
                        RecalcEnabledRequiredStates(oldValue, GetValueFromValues());
                    return;
                }
                SetValueToValues(value);
                RecalcEnabledRequiredStates(oldValue, GetValueFromValues());
                OnPropertyChanged();
            }
        }
        ///<inheritdoc/>
        public IUserFieldDefinition Definition => _definition;
        ///<inheritdoc/>
        public bool IsNull => GetValueFromValues() == null;
        ///<inheritdoc/>
        public bool IsEnabled
        {
            get
            {
                if (_definition.UseRuleEnabled)
                {
                    var enabled = _definition.EnabledRule.Calculate(_custObjParent);
                    if (enabled != _isEnabled)
                    {
                        _isEnabled = enabled;
                    }
                }
                else
                    _isEnabled = false;
                return _isEnabled;
            }
            set { _isEnabled = value; OnPropertyChanged(); }
        }
        ///<inheritdoc/>
        public bool IsRequired
        {
            get
            {
                if (_definition.UseRuleRequired)
                {
                    _isRequired = _definition.RequiredRule.Calculate(_custObjParent);
                }
                else
                    _isRequired = false;
                return _isRequired;
            }
            set { _isRequired = value; OnPropertyChanged(); }
        }
        ///<inheritdoc/>
        public string Error { get; private set; }
        ///<inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Checking field value event
        /// </summary>
        public event EventHandler<CheckRuleEvents> CheckField;
        /// <summary>
        /// Method to call when property changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Get cleared simple typed value
        /// </summary>
        /// <returns></returns>
        protected dynamic GetValueFromValues()
        {
            switch (_definition.Type)
            {
                case CoaFieldTypes.Identifier:
                    if (string.IsNullOrEmpty(_stringValue))
                        _stringValue = OnGetAutoNumberValue(null);
                    return _stringValue;
                case CoaFieldTypes.Bigint:
                    return _longValue;
                case CoaFieldTypes.Boolean:
                    return _boolValue;
                case CoaFieldTypes.Currency:
                    return _decimalValue;
                case CoaFieldTypes.Date:
                    return _datetimeValue;
                case CoaFieldTypes.Decimal:
                    return _decimalValue;
                case CoaFieldTypes.OptionList:
                    if (!_initiated)
                    {
                        if (_tValueInitiated is int && Convert.ToInt32(_tValueInitiated) != 0)
                        {
                            var typedValue = Convert.ToInt64(_tValueInitiated);
                            var detailes = (IOptionListDetailes)_definition.Details;
                            for (int i = 0; i < detailes.Count; i++)
                                if (detailes[i].UniqueId == typedValue)
                                {
                                    _ddlValue = detailes[i];
                                    break;
                                }
                            _initiated = true;
                        }
                        if (_tValueInitiated is string)
                        {
                            _ddlValue = ((IOptionListDetailes)_definition.Details)[Convert.ToString(_tValueInitiated)];
                            _initiated = true;
                        }
                    }
                    return _ddlValue;
                case CoaFieldTypes.Int:
                    return _intlValue;
                case CoaFieldTypes.Object:
                    if (!_initiated)
                    {
                        if (_tValueInitiated is ICustomObject)
                        {
                            _initiated = true;
                        }
                        else
                        {
                            var value = Convert.ToInt64(_tValueInitiated);
                            if (value != 0)
                                _custObjValue = OnGetCustomObject(value);
                            _initiated = true;
                        }
                    }
                    return _custObjValue;
                case CoaFieldTypes.ObjectList:
                    if (_custObjtListValue == null || !_custObjtListValue.IsModified)
                    {
                        _custObjtListValue = OnGetCustomObjectList(_custObjParent.UniqueId, _definition.Id);
                    }
                    return _custObjtListValue;
                case CoaFieldTypes.String:
                case CoaFieldTypes.Text:
                    return _stringValue;
                case CoaFieldTypes.Workflow:
                    return _stateValue;
                case CoaFieldTypes.ShortInt:
                    return _shortValue;
            }
            return null;
        }

        /// <summary>
        /// Set value to variables
        /// </summary>
        /// <param name="value">new value</param>
        protected void SetValueToValues(dynamic value)
        {
            switch (_definition.Type)
            {
                case CoaFieldTypes.Identifier:
                    _stringValue = Convert.ToString(value);
                    break;
                case CoaFieldTypes.Bigint:
                    if (value == null)
                        _longValue = null;
                    else
                        _longValue = Convert.ToInt64(value);
                    break;
                case CoaFieldTypes.Boolean:
                    if (value == null)
                        _boolValue = null;
                    else
                        _boolValue = Convert.ToBoolean(value);
                    break;
                case CoaFieldTypes.Date:
                    {
                        var det = (IDateDetailes)_definition.Details;
                        var midDate = (DateTime?)value;
                        if (det.DateOnly)
                            midDate = midDate?.Date;
                        _datetimeValue = midDate;
                    }
                    break;
                case CoaFieldTypes.Currency:
                case CoaFieldTypes.Decimal:
                    if (value == null)
                        _decimalValue = null;
                    else
                        _decimalValue = Convert.ToDecimal(value);
                    break;
                case CoaFieldTypes.OptionList:
                    SetOptionListValue(value);
                    break;
                case CoaFieldTypes.Int:
                    if (value == null)
                        _intlValue = null;
                    else
                        _intlValue = Convert.ToInt32(value);
                    break;
                case CoaFieldTypes.Object:
                    SetObjectValue(value);
                    break;
                case CoaFieldTypes.ObjectList:
                    SetObjectListValue(value);
                    break;
                case CoaFieldTypes.String:
                case CoaFieldTypes.Text:
                    _stringValue = value;
                    break;
                case CoaFieldTypes.Workflow:
                    SetWorkflowValue(value);
                    break;
                case CoaFieldTypes.ShortInt:
                    if (value == null)
                        _shortValue = null;
                    else
                        _shortValue = Convert.ToInt16(value);
                    break;
            }
        }
        /// <summary>
        /// Set value of type Object
        /// </summary>
        /// <param name="value">UniqueId of object or object</param>
        /// <param name="force">Flage to ignore rule checking, apply only for data from client side</param>
        protected void SetObjectValue(dynamic value, bool force = false)
        {
            if (value == null)
            {
                _custObjValue = value;
                return;
            }
            var midVal = value as CoaCustomObject;
            if (midVal != null)
                _initiated = true;
            else
            {
                midVal = OnGetCustomObject(Convert.ToInt64(value));
                _initiated = true;
            }
            var detailes = (IRefDetailes)_definition.Details;
            var rule = detailes.RestrictionRule as CoaRule;

            var oldValue = _custObjValue;
            try
            {
                var possibleFolderList = new List<int>();
                var currFolder = midVal.CustomObjFolder;
                var refFolder = detailes.ReferencedFolder.UniqueId;
                possibleFolderList.Add(currFolder.UniqueId);
                do
                {
                    currFolder = currFolder.ParentFolder;
                    possibleFolderList.Add(currFolder.UniqueId);
                }
                while (currFolder.UniqueId != refFolder && currFolder.UniqueId != int.MaxValue);
                if (!possibleFolderList.Contains(midVal.CustomObjFolder.UniqueId))
                    throw new CoaUserFieldException(Resource.CoaUserFieldAnotherFolderException);
                _custObjValue = midVal;
                if (!force && detailes.Restriction && !(rule?.Calculate(midVal, _custObjParent) ?? true))// error - substitute an object that is the value of the parent object and the object for the rule.
                    throw new RestrictionRuleFailedException();
            }
            catch (RestrictionRuleFailedException)
            {
                _custObjValue = oldValue;
                throw new RestrictionRuleFailedException(detailes.RestrictionOptionalErrorMessage ?? string.Format(Resource.RestrictionRuleFailedException_ForField, _definition.Label));
            }
            catch (Exception ex)
            {
                _custObjValue = oldValue;
                throw new CoaUserFieldException(ex);
            }
        }
        /// <summary>
        /// Setting value to field of type ObjectList
        /// </summary>
        /// <param name="value">Object of type ICustomObjects</param>
        /// <param name="force">Force set data</param>
        /// <param name="addingcustomObjs">Array identifiers UniqueId of adding objects</param>
        /// <param name="deletedcustomObjIds">Array identifiers UniqueId of removing objects</param>
        protected void SetObjectListValue(dynamic value, bool force = false, long[] addingcustomObjs = null, long[] deletedcustomObjIds = null)
        {
            if (value == null)
                return;
            if (!force)
            {
                if (value as ICustomObjects == null)
                    throw new CoaUserFieldException(Resource.CoaUserFieldArgumentObjListTypeException);
                if (_custObjtListValue == null)
                    _custObjtListValue = OnGetCustomObjectList(_custObjParent.UniqueId, _definition.Id);
                if (_custObjtListValue.Parent == value.Parent)
                    _custObjtListValue = value;
                else
                    throw new CoaUserFieldException(Resource.CoaUserFieldForeignCollectionException);
            }
            else
            {
                if (addingcustomObjs == null || deletedcustomObjIds == null)
                    throw new CoaUserFieldException(Resource.CoaUserFieldIncorrectInitializationException);
                for (var i = 0; i < addingcustomObjs.Length; i++)
                {
                    value.AddExistingById(addingcustomObjs[i]);
                }
                for (var i = 0; i < deletedcustomObjIds.Length; i++)
                {
                    value.RemoveExistingById(deletedcustomObjIds[i]);
                }
            }
        }

        /// <summary>
        /// Set initial value
        /// </summary>
        /// <param name="value"></param>
        protected void SetValueOnInit(dynamic value)
        {
            switch (_definition.Type)
            {
                case CoaFieldTypes.Workflow:
                    {
                        var detailes = (IWorkflowDetails)_definition.Details;
                        if (value?.GetType() != typeof(int))
                        {
                            _stateValue = value != null
                                ? detailes.States[value.ToString()]
                                : detailes.States.InitialState;
                        }
                        else
                        {
                            var val = Convert.ToInt32(value);
                            var finded = false;
                            for (var i = 0; i < detailes.States.Count; i++)
                            {
                                if (detailes.States[i].Id == val)
                                {
                                    _stateValue = detailes.States[i];
                                    finded = true;
                                    break;
                                }
                            }
                            if (!finded)
                                _stateValue = detailes.States.InitialState;
                        }
                        _tValueInitiated = _stateValue;
                    }
                    break;
                case CoaFieldTypes.Object:
                    {
                        if (value == null)
                        {
                            _custObjValue = value;
                            return;
                        }
                        var midVal = value as CoaCustomObject;
                        if (!(value is ICustomObject))
                        {
                            var objId = Convert.ToInt64(value);
                            midVal = OnGetCustomObject(objId);
                        }
                        _initiated = true;
                        _custObjValue = midVal;
                        _tValueInitiated = _custObjValue;
                    }
                    break;
                case CoaFieldTypes.ObjectList:
                    {
                        // TODO: We return a new object each time so that the initialization is done again.
                        // We do this in order to have a dynamic update in the hope that the user will save a copy of the object to a variable, and not break the link every time.
                        // That is, a potential bug in the project until all references are removed. customObjs.Count () and the like
                        if (value != null && !value?.IsModified)
                            _custObjtListValue = OnGetCustomObjectList(_custObjParent.UniqueId, _definition.Id);
                        _tValueInitiated = _custObjtListValue;
                        _initiated = false;//endless initialization?
                    }
                    break;
                case CoaFieldTypes.OptionList:
                    {
                        if (value == null)
                        {
                            _ddlValue = null;
                        }
                        else
                        {
                            if (value is int && Convert.ToInt32(value) != 0)
                            {
                                var det = (IOptionListDetailes)_definition.Details;
                                for (int i = 0; i < det.Count; i++)
                                    if (det[i].UniqueId == value)
                                    {
                                        _ddlValue = det[i];
                                        break;
                                    }
                            }
                            else
                                _ddlValue = ((IOptionListDetailes)_definition.Details)[value];
                        }
                        _initiated = true;
                        _tValueInitiated = _ddlValue;
                    }
                    break;
                case CoaFieldTypes.Date:
                    {
                        var det = (IDateDetailes)_definition.Details;
                        var midValue = value;
                        if (midValue == null && _definition.DefaultValue != null)
                            midValue = (DateTime?)_definition.DefaultValue;

                        if (det.CreationDateAsDefault && _custObjParent.UniqueId == 0)
                            midValue = _custObjParent.Created;
                        if (det.DateOnly)
                            midValue = ((DateTime?)midValue)?.Date;
                        _datetimeValue = midValue;
                        _tValueInitiated = _datetimeValue;
                        _initiated = true;
                    }
                    break;
                case CoaFieldTypes.Identifier:
                    _stringValue = OnGetAutoNumberValue(value);
                    _initiated = true;
                    break;
                default:
                    SetValueToValues(value);
                    _tValueInitiated = GetValueFromValues();
                    break;
            }
        }
        /// <summary>
        /// Reset initial value to current
        /// </summary>
        protected void ResetModified()
        {
            _tValueInitiated = TValue;
        }
        /// <summary>
        /// Method to call update object list value
        /// </summary>
        protected internal void UpdateObjectLists()
        {
            _custObjtListValue = OnGetCustomObjectList(_custObjParent.UniqueId, _definition.Id);
        }
        private void RecalcEnabledRequiredStates(object oldValue, object newValue)
        {
            //Check current field
            if (_definition.UseRuleEnabled)
                IsEnabled = _definition.EnabledRule.Calculate(_custObjParent);
            else
                _isEnabled = false;
            if (_definition.UseRuleRequired)
            {
                IsRequired = _definition.RequiredRule.Calculate(_custObjParent);
            }
            else
                _isRequired = false;
            //Call check rule
            var args = new CheckRuleEvents(_definition.Alias, oldValue, newValue);
            CheckField?.Invoke(this, args);
        }
        /// <summary>
        /// Get object instance by id
        /// </summary>
        /// <returns></returns>
        protected abstract ICustomObject OnGetCustomObject(long id);
        /// <summary>
        /// Implementation getting custom object collection by object Id and field identifier
        /// </summary>
        /// <returns></returns>
        protected abstract CoaCustomObjects OnGetCustomObjectList(long customObjId, int fieldId);
        /// <summary>
        /// Implementation getting value for autonumber field
        /// </summary>
        /// <param name="value">Field value from server (database)</param>
        /// <returns></returns>
        protected abstract string OnGetAutoNumberValue(dynamic value);
        private void SetOptionListValue(dynamic value)
        {
            var det = (IOptionListDetailes)_definition.Details;
            if (value is string)
                _ddlValue = value != null ? det[value?.ToString()] : _tValueInitiated;
            if (value is int)
            {
                for (var i = 0; i < det.Count; i++)
                    if (det[i].UniqueId == value)
                    {
                        _ddlValue = det[i];
                        break;
                    }
            }
            _initiated = true;
        }

        private void SetWorkflowValue(dynamic value)
        {
            if (value == null && _tValueInitiated == null)
                _stateValue = _tValueInitiated;
            else
            {
                if (value == null)
                    throw new WorkflowNullValueException();
                var settingValue = !string.IsNullOrEmpty(value?.ToString()) ?
                    ((IWorkflowDetails)_definition.Details).States[value.ToString()]
                    : ((IWorkflowDetails)_definition.Details).States.InitialState;
                if (_custObjParent.UniqueId == 0 && !settingValue.Initial)
                {
                    var flags = (_custObjParent as CoaCustomObject)?.SavingFlags;
                    if (!((flags & CoaEnumSaveFlags.DoNotValidateInput) == CoaEnumSaveFlags.DoNotValidateInput))
                        throw new CoaUserFieldException(Resource.CoaUserFieldInitializationValueException);
                }
                _stateValue = settingValue;
                _initiated = true;
            }
        }
        private string Validate([CallerMemberName] string propertyName = null)
        {
            string validationMessage = null;
            if (propertyName != "TValue")
            {
                return validationMessage;
            }

            switch (_definition.Type)
            {
                case CoaFieldTypes.String:
                    {
                        var det = (ITextDetails)_definition.Details;
                        var value = GetValueFromValues();
                        if (det.MinSize > 0 && !string.IsNullOrEmpty(value))
                        {
                            if (value.ToString().Length < det.MinSize)
                            {
                                validationMessage = string.Format(Resource.CoaUserFieldValidationLessThenErrorMessage, _definition.Label, det.MinSize);
                                break;
                            }

                        }
                        if (!string.IsNullOrEmpty(det.MustMatch))
                        {
                            var reg = new Regex(det.MustMatch);
                            if (!reg.IsMatch(value))
                                validationMessage = det.ErrorMessage;
                        }
                        if (det.MaxSize > 0 && !string.IsNullOrEmpty(value))
                            if (det.MaxSize < value.Length)
                            {
                                validationMessage = string.Format(Resource.CoaUserFieldValidationGreaterThenErrorMessage, _definition.Label, det.MaxSize);

                            }
                    }
                    break;
            }
            Error = validationMessage;
            return validationMessage;
        }
        
    } 
}
