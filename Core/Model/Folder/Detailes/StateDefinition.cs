using CoaApp.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class StateDefinitions: AppBase, IStateDefinitions
    {
        private readonly IList<IState> _items = new List<IState>();
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected StateDefinitions(IApplication app, object parent) : base(app, parent)
        {

        }
        /// <summary>
        /// Initiating existing data;
        /// </summary>
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/param[@name="app"]'/>
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/param[@name="parent"]'/>
        /// <param name="existedStates">Existed states</param>
        protected StateDefinitions(IApplication app, object parent, IEnumerable<IState> existedStates) : base(app, parent)
        {
            _items = existedStates.ToList();
        }
        ///<inheritdoc/>
        public IState this[int idx] => _items[idx];
        ///<inheritdoc/>
        public IState this[string alias] => _items.SingleOrDefault(x=> x.Code == alias);
        ///<inheritdoc/>
        public IState InitialState => _items.SingleOrDefault(x=> x.Initial);
        ///<inheritdoc/>
        public int Count => _items.Count;
        ///<inheritdoc/>
        public void Add(IState state)
        {
            _items.Add(state);
        }
        ///<inheritdoc/>
        public abstract IState Create();
        ///<inheritdoc/>
        public void Remove(int idx)
        {
            _items.RemoveAt(idx);
        }
        ///<inheritdoc/>
        public void Remove(IState state)
        {
            _items.Remove(state);
        }
    }
}
