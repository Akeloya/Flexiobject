using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;

namespace CoaApp.Core.Model.Folder.Detailes
{
    /// <inheritdoc/>
    public abstract class Action : AppBase, IAction
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected Action(IApplication app, object parent) : base(app, parent)
        {
        }
        /// <inheritdoc/>
        public int Id { get; protected set; }
        /// <inheritdoc/>
        public CoaActionTypes Type { get; set; }
        /// <inheritdoc/>
        public string Name { get; set; }
        /// <inheritdoc/>
        public string Desctiption { get; set; }
        /// <inheritdoc/>
        public abstract void Save();
    }
}
