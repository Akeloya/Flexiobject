using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class TextDetailes : AppBase, ITextDetails
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected TextDetailes(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public string ErrorMessage { get; set; }
        ///<inheritdoc/>
        public int MaxSize { get; set; }
        ///<inheritdoc/>
        public int MinSize { get; set; }
        ///<inheritdoc/>
        public string MustMatch { get; set; }
    }
}
