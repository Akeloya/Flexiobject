using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class NumberDetailes : AppBase, INumberDetailes
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected NumberDetailes(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract bool ThousandsSeparator { get; set; }
    }
}
