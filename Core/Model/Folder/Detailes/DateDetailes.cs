using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class DateDetailes : AppBase, IDateDetailes
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected DateDetailes(IApplication app, object parent): base(app, parent)
        {

        }
        ///<inheritdoc/>
        public bool CreationDateAsDefault { get; set; }
        ///<inheritdoc/>
        public bool CurrentDateTime { get; set; }
        ///<inheritdoc/>
        public bool DateOnly { get; set; }
        ///<inheritdoc/>
        public bool TimezoneIndependent { get; set; }
    }
}
