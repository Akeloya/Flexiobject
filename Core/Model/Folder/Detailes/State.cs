using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class State : AppBase, IState
    {
        private bool _initial;
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected State(IApplication app, object parent) : base(app, parent)
        {

        }
        /// <summary>
        /// Constructor for initiating existed state
        /// </summary>
        /// <param name="app">Reference to app instance</param>
        /// <param name="parent">Reference to parent object</param>
        /// <param name="initial">Initial state</param>
        protected State(IApplication app, object parent, bool initial) : base(app, parent)
        {
            _initial = initial;
        }
        ///<inheritdoc/>
        public string Title { get; set; }
        ///<inheritdoc/>
        public string Code { get; set; }
        ///<inheritdoc/>
        public int Id { get; protected set; }
        ///<inheritdoc/>
        public bool Initial
        {
            get
            {
                return _initial;
            }
            set
            {
                if(value)
                    OnSetInitial();
                _initial = value;
            }
        }
        ///<inheritdoc/>
        public string Description { get; set; }
        ///<inheritdoc/>
        public abstract void Remove();
        /// <summary>
        /// Clear all initial on setting current to initial=true
        /// </summary>
        protected abstract void OnSetInitial();
    }
}
