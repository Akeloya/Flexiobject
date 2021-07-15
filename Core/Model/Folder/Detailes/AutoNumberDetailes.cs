using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class AutoNumberDetailes : AppBase, IAutoNumberDetailes
    {
        /// <include file='commonDocs.xml' path='docs/members[@name="constructors"]/defaultProtected/*'/>
        protected AutoNumberDetailes(IApplication app, object parent): base(app, parent)
        {

        }
        ///<inheritdoc/>
        public int FieldWidth { get; set; }
        ///<inheritdoc/>
        public bool InheritSettings { get; set; }
        ///<inheritdoc/>
        public bool FillZeroes { get; set; }
        ///<inheritdoc/>
        public int InitialValue { get; set; }
        ///<inheritdoc/>
        public string Prefix { get; set; }
        ///<inheritdoc/>
        public bool ShareNumbersWithSubfolders { get; set; }
        ///<inheritdoc/>
        public string Suffix { get; set; }
        ///<inheritdoc/>
        public long ToNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0L;
            var numb = value;
            if (!string.IsNullOrEmpty(Prefix) && value.Contains(Prefix))
                numb = numb.Replace(Prefix, null);
            if (!string.IsNullOrEmpty(Suffix) && numb.Contains(Suffix))
                numb = numb.Replace(Suffix, null);
            if (long.TryParse(numb, out long result))
                return result;
            return 0L;
        }
    }
}
