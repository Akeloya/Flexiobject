using FlexiObject.Core.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace FlexiObject.API.Model.Object
{
    public abstract class History : AppBase, IHistory
    {
        /// <summary>
        /// History constructor for existing object
        /// </summary>
        /// <param name="app">Link to application</param>
        /// <param name="parent">Link to object-creator</param>
        /// <param name="custObjUniqueId">Existing object uniqueId</param>
        protected History(Application app, object parent, long custObjUniqueId) : base(app, parent)
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
            if (_records == null)
            {
                _records = new List<IHistoryRecord>();
                if (_objUniqueId != 0)
                    _records.AddRange(OnGetHistory(_objUniqueId));
            }
            return _records;
        }
    }
}
