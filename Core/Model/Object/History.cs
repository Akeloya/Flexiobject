/*
 *  "Flexiobject core"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
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

using FlexiObject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.Core
{
    public abstract class History<T> : AppBase<T>, IHistory
    {
        /// <summary>
        /// History constructor for existing object
        /// </summary>
        /// <param name="app">Link to application</param>
        /// <param name="parent">Link to object-creator</param>
        /// <param name="custObjUniqueId">Existing object uniqueId</param>
        protected History(Application app, T parent, long custObjUniqueId) : base(app, parent)
        {
            _objUniqueId = custObjUniqueId;
        }        

        private long _objUniqueId;

        private List<IHistoryRecord> _records;
        public IHistoryRecord this[int idx]
        {
            get
            {
                return GetHistory()[idx];
            }
        }

        public int Count => GetHistory().Count();
        /// <summary>
        /// Get History records realization
        /// </summary>
        /// <param name="objId">Object UniqueId</param>
        /// <returns>History records</returns>
        protected virtual IEnumerable<IHistoryRecord> OnGetHistory(long objId)
        {
            return new List<IHistoryRecord>();
        }

        private List<IHistoryRecord> GetHistory()
        {
            if(_records == null)
            {
                _records = new List<IHistoryRecord>();
                if (_objUniqueId != 0)
                    _records.AddRange(OnGetHistory(_objUniqueId));
            }
            return _records;
        }
    }
}
