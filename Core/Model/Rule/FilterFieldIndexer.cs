using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    /// <summary>
    /// Acces to filter fields
    /// </summary>
    [Serializable]
    internal class FilterFieldIndexer : IFilterFieldIndexer
    {
        private readonly Get _get;
        private readonly Set _set;
        internal FilterFieldIndexer(Get get, Set set)
        {
            _get = get ?? throw new ArgumentNullException(nameof(get));
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }
        /// <summary>
        /// Get 
        /// </summary>
        /// <param name="name">Field alias</param>
        /// <returns>Return value</returns>
        public object this[string name]
        {
            get
            {
                var e = new CoaFilterFieldArgs { FieldName = name };
                _get(e);
                return e.Value;
            }
            set { _set(new CoaFilterFieldArgs { FieldName = name, Value = value }); }
        }

        internal delegate void Get(CoaFilterFieldArgs args);
        internal delegate void Set(CoaFilterFieldArgs args);
    }
    /// <summary>
    /// Results of call delegate set or get for FilterFieldIndexer
    /// </summary>
    [Serializable]
    internal class CoaFilterFieldArgs
    {
        /// <summary>
        /// Название поля
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public object Value { get; set; }

    }
}
