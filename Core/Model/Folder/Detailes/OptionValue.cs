using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class OptionListValue: AppBase, IOptionListValue
    {
        private int _id;
        private IOptionListValue _next;
        private IOptionListValue _prew;
        private int _position;
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        /// <param name="id">Identifier value</param>
        /// <param name="name">Name value</param>
        /// <param name="alias">Alias value</param>
        /// <param name="description">Description value</param>
        /// <param name="position">Level value</param>
        protected OptionListValue(IApplication app, object parent, int id, string name, string alias,
            string description, int position) : base(app, parent)
        {
            Name = name;
            Alias = alias;
            _id = id;
            Description = description;
            _position = position;
        }
        ///<inheritdoc/>
        public string Alias { get; set; }
        ///<inheritdoc/>
        public string Description { get; set; }
        ///<inheritdoc/>
        public string Name { get; set; }
        ///<inheritdoc/>
        public int Position { get; internal protected set; }
        ///<inheritdoc/>
        public IOptionListValue Predecessor => _prew;
        ///<inheritdoc/>
        public IOptionListValue Successor => _next;
        ///<inheritdoc/>
        public int UniqueId => _id;
        /// <summary>
        /// Implementation ToString() method
        /// </summary>
        /// <returns>Returns Alias</returns>
        public override string ToString()
        {
            return Alias;
        }
        /// <summary>
        /// Update prew, next and position after swap
        /// </summary>
        /// <param name="prew">Prew value</param>
        /// <param name="next">Next value</param>
        protected void UpdatePosition(IOptionListValue prew, IOptionListValue next)
        {
            _prew = prew;
            _next = next;
        }
        /// <summary>
        /// Setting identifier when it updated was updated
        /// </summary>
        /// <param name="id">Newly identificator value</param>
        protected void SetId(int id)
        {
            _id = id;
        }
    }
}
