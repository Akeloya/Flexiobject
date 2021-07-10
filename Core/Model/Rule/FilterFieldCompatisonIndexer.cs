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
        private Get _get;
        private Set _set;
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
