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

namespace CoaApp.Core
{
    /// <summary>
    /// Acces to filter fields
    /// </summary>
    [Serializable]
    internal class FilterFieldIndexer : IFilterFieldIndexer
    {
        private Get _get;
        private Set _set;
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
