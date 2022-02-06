using CoaApp.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CoaApp.Core.Model.Folder.Detailes
{
    ///<inheritdoc/>
    public abstract class StateTransitions: AppBase, IStateTransitions
    {
        private readonly IList<IStateTransition> _items = new List<IStateTransition>();
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected StateTransitions(IApplication app, object parent): base(app, parent)
        {

        }
        /// <summary>
        /// Constructor for existed data
        /// </summary>
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/param[@name="app"]'/>
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/param[@name="parent"]'/>
        /// <param name="existedItems">Existed transition state items</param>
        protected StateTransitions(IApplication app, object parent, IEnumerable<IStateTransition> existedItems) : base(app, parent)
        {
            _items = existedItems.ToList();
        }
        ///<inheritdoc/>
        public IStateTransition this[int idx] => _items[idx];
        ///<inheritdoc/>
        public int Count => _items.Count;
        ///<inheritdoc/>
        public void Add(IStateTransition transition)
        {
            _items.Add(transition);
        }
        ///<inheritdoc/>
        public abstract IStateTransition Create();
        ///<inheritdoc/>
        public void Remove(int idx)
        {
            _items.RemoveAt(idx);
        }
        ///<inheritdoc/>
        public void Remove(IStateTransition transition)
        {
            _items.Remove(transition);
        }
    }
}
