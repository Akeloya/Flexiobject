using CoaApp.Core.Interfaces;
using System;
using CoaApp.Core.Enumes;

namespace CoaApp.Core
{
    /// <summary>
    /// Access to indexer of comparier rule
    /// </summary>
    [Serializable]
    internal class CoaFilterFieldCompatisonIndexer : IFilterFieldCompatisonIndexer
    {
        private readonly Get _get;
        private readonly Set _set;
        public CoaFilterFieldCompatisonIndexer(Get get, Set set)
        {
            _get = get ?? throw new ArgumentNullException(nameof(get));
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }
        /// <summary>
        /// Access to comparier
        /// </summary>
        /// <param name="name">Field name</param>
        /// <returns></returns>
        public CoaRuleComparisonsTypes? this[string name] 
        {
            get
            {
                var e = new CoaFilterFieldComparisonArgs { FieldName = name };
                _get(e);
                return e.Value;
            }
            set { _set(new CoaFilterFieldComparisonArgs { FieldName = name, Value = value }); }
        }
        internal delegate void Get(CoaFilterFieldComparisonArgs e);
        internal delegate void Set(CoaFilterFieldComparisonArgs e);
    }
    /// <summary>
    /// Field access result event
    /// </summary>
    [Serializable]
    internal class CoaFilterFieldComparisonArgs
    {
        /// <summary>
        /// Field name
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Value of comparison
        /// </summary>
        public CoaRuleComparisonsTypes? Value { get; set; }
    }
}
