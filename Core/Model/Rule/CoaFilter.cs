using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System.Linq;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaFilter : AppBase, IFilter
    {
        private IRule _rule;
        private readonly ICustomFolder _folder;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="folder"></param>
        protected CoaFilter(IApplication app, ICustomFolder folder): base(app, folder)
        {
            _folder = folder;
            _rule = GetRuleInstance(app, this, folder);
        }
        ///<inheritdoc/>
        public IFilterFieldIndexer UserField => new FilterFieldIndexer(UserFieldGet, UserFieldSet);
        ///<inheritdoc/>
        public IRule Rule { get => _rule; set => _rule = value; }
        ///<inheritdoc/>
        public IFilterFieldCompatisonIndexer UserFieldComparison => new CoaFilterFieldCompatisonIndexer(UserFieldComparisonGet, UserFieldComparisonSet);
        ///<inheritdoc/>
        public ICustomFolder Folder => _folder;
        ///<inheritdoc/>
        public void Combine(IFilter filter, CoaRuleCombinationTerms term)
        {
            if (_rule.Combination == CoaRuleCombinationTerms.Term || _rule.Combination != term)
            {
                var item = _rule;
                _rule = GetRuleInstance(Application, this, Folder);
                _rule.ChiledRules.Add(item);
            }
            _rule.Combination = term;
            _rule.ChiledRules.Add(filter.Rule);
        }
        private void UserFieldComparisonGet(CoaFilterFieldComparisonArgs args)
        {
            var item = _rule.ChiledRules.Single(x => x.LeftSideFieldPath == args.FieldName);
            args.Value = item?.CombinationOperator;
        }
        private void UserFieldComparisonSet(CoaFilterFieldComparisonArgs args)
        {
            var item = _rule;
            if (item?.Combination != CoaRuleCombinationTerms.Term)
                item = (IRule)_rule?.ChiledRules.SingleOrDefault(x => x.LeftSideFieldPath == args.FieldName);
            if (item == null)
            {
                item = GetRuleInstance(Application, this, Folder);
                item.LeftSideFieldPath = args.FieldName;
                item.CombinationOperator = args.Value;
                item.RightSideType = CoaRuleRightSideTypes.Constant;
                item.LeftSideType = CoaRuleLeftSideTypes.FieldPath;
                item.Combination = CoaRuleCombinationTerms.Term;
                if (_rule != null)
                {
                    if (_rule.Combination != CoaRuleCombinationTerms.Term)
                    {
                        _rule.ChiledRules.Add(item);
                    }
                    else
                    {
                        var itemRoot = _rule;
                        _rule = GetRuleInstance(Application, this, Folder);
                        _rule.Combination = CoaRuleCombinationTerms.And;
                        _rule.ChiledRules.Add(itemRoot);
                        _rule.ChiledRules.Add(item);
                    }
                }
                if (_rule == null)
                    _rule = item;
            }
            item.CombinationOperator = args.Value;
        }
        private void UserFieldGet(CoaFilterFieldArgs args)
        {
            var item = _rule.ChiledRules.Single(x => x.LeftSideFieldPath == args.FieldName);
            args.Value = item?.RightSideValue;
        }
        private void UserFieldSet(CoaFilterFieldArgs args)
        {
            var item = _rule;
            if (item?.Combination != CoaRuleCombinationTerms.Term)
                item = _rule?.ChiledRules.SingleOrDefault(x => x.LeftSideFieldPath == args.FieldName);
            else
                item.LeftSideFieldPath = args.FieldName;
            if (item == null)
            {
                item = GetRuleInstance(Application, this, Folder);
                item.LeftSideFieldPath = args.FieldName;
                item.RightSideValue = args.Value;
                item.RightSideType = CoaRuleRightSideTypes.Constant;
                item.LeftSideType = CoaRuleLeftSideTypes.FieldPath;
                item.Combination = CoaRuleCombinationTerms.Term;
                item.CombinationOperator = CoaRuleComparisonsTypes.EqualTo;

                if (_rule != null)
                {
                    if (_rule.Combination != CoaRuleCombinationTerms.Term)
                    {
                        _rule.ChiledRules.Add(item);
                    }
                    else
                    {
                        var itemRoot = _rule;
                        _rule = GetRuleInstance(Application, this, Folder);
                        _rule.Combination = CoaRuleCombinationTerms.And;
                        _rule.ChiledRules.Add(itemRoot);
                        _rule.ChiledRules.Add(item);
                    }
                }
                if (_rule == null)
                    _rule = item;
            }
            item.RightSideValue = args.Value;
        }
        ///<inheritdoc/>
        public abstract void Save();
        /// <summary>
        /// Get Rule instance method declaration
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        protected abstract IRule GetRuleInstance(IApplication app, object parent, ICustomFolder folder);
    }
}