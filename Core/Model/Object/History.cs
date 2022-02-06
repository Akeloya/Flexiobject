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
