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
using System.Collections.Generic;
using System.Linq;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class History: AppBase, IHistory
    {
        private readonly long _custObjUniqueId;
        private IEnumerable<IHistoryRecord> _records;
        /// <summary>
        /// History constructor for existing object
        /// </summary>
        /// <param name="app">Link to application</param>
        /// <param name="parent">Link to object-creator</param>
        /// <param name="custObjUniqueId">Existing object uniqueId</param>
        protected History(IApplication app, object parent, long custObjUniqueId) : base(app, parent)
        {
            _custObjUniqueId = custObjUniqueId;
        }
        ///<inheritdoc/>
        public IHistoryRecord this[int idx]
        {
            get
            {
                return GetHistory().ElementAt(idx);
            }
        }
        ///<inheritdoc/>
        public int Count => GetHistory().Count();
        private IEnumerable<IHistoryRecord> GetHistory()
        {
            if (_records == null)
            {                
                if (_custObjUniqueId != 0)
                    _records = OnGetHistory(_custObjUniqueId);
            }
            return _records;
        }
        /// <summary>
        /// Get History records realization
        /// </summary>
        /// <param name="custObjId">Custom object UniqueId</param>
        /// <returns>History records</returns>
        protected abstract IEnumerable<IHistoryRecord> OnGetHistory(long custObjId);
    }
}
