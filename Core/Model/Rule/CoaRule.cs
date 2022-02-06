﻿using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using CoaApp.Core.Model.Rule;
using CoaApp.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaRule : AppBase, IRule
    {
        private readonly IList<IRule> _chiledRules;
        private readonly ICustomFolder _folder;
        private CoaRuleCombinationTerms _combination = CoaRuleCombinationTerms.Term;
        private int[] _leftSideFieldPath;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="folder"></param>
        protected CoaRule(IApplication app, object parent, ICustomFolder folder) : base(app, parent)
        {
            _chiledRules = new List<IRule>();
            _folder = folder;
        }
        ///<inheritdoc/>
        public CoaRuleComparisonsTypes? CombinationOperator { get; set; }
        ///<inheritdoc/>
        public string Data { get; set; }
        ///<inheritdoc/>
        public IList<IRule> ChiledRules => _chiledRules;
        ///<inheritdoc/>
        public CoaRuleCombinationTerms Combination { get => _combination; set => _combination = value; }
        ///<inheritdoc/>
        public CoaRuleRightSideTypes RightSideType { get; set; }
        ///<inheritdoc/>
        public CoaRuleLeftSideTypes LeftSideType { get; set; }
        ///<inheritdoc/>
        public string LeftSideFieldPath
        {
            get
            {
                if (_leftSideFieldPath == null)
                    return null;
                return CoaUserFieldDefinition.GetFieldPathByFieldIds(_folder, _leftSideFieldPath);
            }
            set
            {
                InitiateAffectedFields(value);
            }
        }
        ///<inheritdoc/>
        public object RightSideValue { get; set; }
        ///<inheritdoc/>
        public object LeftSideValue { get; set; }
        ///<inheritdoc/>
        public IUserFieldDefinitions AffectedFields { get { return OnGetffectedFields(_leftSideFieldPath); } }
        ///<inheritdoc/>
        public bool Calculate(ICustomObject custObj)
        {
            return Calculate(this, custObj, custObj, Application, RightSideValue);
        }
        ///<inheritdoc/>
        public void Clear()
        {
            _chiledRules.Clear();
            LeftSideFieldPath = string.Empty;
            LeftSideValue = null;
            RightSideValue = null;
        }
        ///<inheritdoc/>
        public override string ToString()
        {
            return BuildStringRule();
        }
        internal bool Calculate(ICustomObject custObj, ICustomObject baseCustObj)
        {
            return Calculate(this, custObj, baseCustObj, Application, RightSideValue);
        }
        /// <summary>
        /// Recursive calculating rule
        /// </summary>
        /// <param name="rule">Current branch rule</param>
        /// <param name="custObj">Object calculating rule for</param>
        /// <param name="basecustObj"></param>
        /// <param name="app">Link to Application</param>
        /// <param name="rightSideValue"></param>
        /// <returns>Calculating result</returns>
        private static bool Calculate(IRule rule, ICustomObject custObj, ICustomObject basecustObj, IApplication app, object rightSideValue = null)
        {
            var result = false;
            if (rule.Combination == CoaRuleCombinationTerms.Term)
            {
                result = CalculateTerm(rule, custObj, basecustObj, app, rightSideValue, result);
            }
            else
            {
                if (rule.Combination == CoaRuleCombinationTerms.And)
                {
                    result = rule.ChiledRules.Aggregate(true, (current, chiledRule) => current && Calculate(chiledRule, custObj, basecustObj, app));
                }
                if (rule.Combination == CoaRuleCombinationTerms.Or)
                {
                    result = rule.ChiledRules.Aggregate(false, (current, chiledRule) => current || Calculate(chiledRule, custObj, basecustObj, app));
                }
            }
            return result;
        }

        private static bool CalculateTerm(IRule rule, ICustomObject custObj, ICustomObject basecustObj, IApplication app, object rightSideValue, bool result)
        {
            switch (rule.LeftSideType)
            {
                case CoaRuleLeftSideTypes.FieldPath:
                    {
                        if (string.IsNullOrEmpty(rule.LeftSideFieldPath))
                            result = true;
                        else
                        {
                            var fields = rule.LeftSideFieldPath.Split('.');
                            IUserField field = custObj.UserFields[fields[0]];
                            for (var i = 1; i < fields.Length; i++)
                            {
                                var rq = (ICustomObject)field.TValue;
                                field = rq.UserFields[fields[i]];
                            }
                            result = RuleCompariers.CompareField(field,
                                rule.CombinationOperator ?? CoaRuleComparisonsTypes.EqualTo,
                                rule.RightSideValue,
                                rule.RightSideType, basecustObj, app);
                        }
                    }
                    break;
                case CoaRuleLeftSideTypes.CurrentUser:
                    result = RuleCompariers.CompareCurrentUser(rule.RightSideValue,
                        rule.CombinationOperator ?? CoaRuleComparisonsTypes.Is, app);
                    break;
                case CoaRuleLeftSideTypes.Folder:
                    result = RuleCompariers.CompareFolder(custObj.CustomObjFolder, (ICustomFolder)rule.RightSideValue,
                        rule.CombinationOperator ?? CoaRuleComparisonsTypes.Is);
                    break;
                case CoaRuleLeftSideTypes.FolderAliasName:
                    result = RuleCompariers.CompareStrings(custObj.CustomObjFolder.Alias, rule.RightSideValue.ToString(),
                        rule.CombinationOperator ?? CoaRuleComparisonsTypes.EqualTo);
                    break;
                case CoaRuleLeftSideTypes.FolderName:
                    result = RuleCompariers.CompareStrings(custObj.CustomObjFolder.Name, rule.RightSideValue.ToString(),
                        rule.CombinationOperator ?? CoaRuleComparisonsTypes.EqualTo);
                    break;
                case CoaRuleLeftSideTypes.UniqueId:
                    result = RuleCompariers.CompareLongs(custObj.UniqueId, (int)rightSideValue,
                        rule.CombinationOperator ?? CoaRuleComparisonsTypes.EqualTo);
                    break;
            }

            return result;
        }

        private string BuildStringRule()
        {
            var result = string.Empty;
            if (_combination == CoaRuleCombinationTerms.Term)
            {
                if (string.IsNullOrEmpty(LeftSideFieldPath))
                    return Resource.CoaRuleStringAlways;
                else
                    result = GetRuleEntityString(this);
                return result;
            }
            if (_chiledRules.Count > 0)
                result = BuildStringRuleChiled(_chiledRules[0]);
            for (var i = 1; i < _chiledRules.Count; i++)
            {
                result += " " + Combination.ToStringValue() + " " + BuildStringRuleChiled(_chiledRules[i]);
            }
            return result;
        }

        private string BuildStringRuleChiled(IRule rule)
        {
            var result = string.Empty;
            if (rule.ChiledRules.Count == 0)
            {
                return GetRuleEntityString(rule);
            }

            if (rule.ChiledRules.Count > 0)
                result = BuildStringRuleChiled(rule.ChiledRules[0]);
            for (var i = 1; i < rule.ChiledRules.Count; i++)
            {
                result += " " + rule.Combination.ToStringValue() + " " + BuildStringRuleChiled(rule.ChiledRules[i]);
            }
            return result;
        }

        private string GetRuleEntityString(IRule rule)
        {
            return $"({CoaUserFieldDefinition.GetFieldByPath(_folder, rule.LeftSideFieldPath).Label} " +
                $"{rule.CombinationOperator.ToStringValue()} {rule.RightSideValue})";
        }
        /// <summary>
        /// Initializing the fields that make up the path of the left side of the expression <seealso cref="LeftSideFieldPath"/>
        /// </summary>
        private void InitiateAffectedFields(string value)
        {
            if (value == null)
            {
                _leftSideFieldPath = Array.Empty<int>();
                return;
            }
            var fields = CoaUserFieldDefinition.GetFieldsByPath(_folder, value);
            if (fields.Count > 0 && fields[0] != null)
                _leftSideFieldPath = new int[fields.Count];
            else
            {
                _leftSideFieldPath = Array.Empty<int>();
                return;
            }
            for (var i = 0; i < fields.Count; i++)
                _leftSideFieldPath[i] = fields[i].Id;
        }
        /// <summary>
        /// Get rule instance method declaration
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        protected internal abstract IRule GetInstance(IApplication app);
        /// <summary>
        /// Get affected field method declaration
        /// </summary>
        /// <param name="fieldIds"></param>
        /// <returns></returns>
        protected abstract IUserFieldDefinitions OnGetffectedFields(int[] fieldIds);
    }
}
