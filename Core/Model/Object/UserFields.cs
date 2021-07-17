using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class UserFields : AppBase, IUserFields
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected UserFields(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public IUserField this[int idx] => OnGetFieldByIndex(idx);
        ///<inheritdoc/>
        public IUserField this[string alias] => OnGetFieldByAlias(alias);
        ///<inheritdoc/>
        public int Count => OnGetCount();
        /// <summary>
        /// Get User fields count
        /// </summary>
        /// <returns></returns>
        protected abstract int OnGetCount();        
        /// <summary>
        /// Get User field by index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        protected abstract IUserField OnGetFieldByIndex(int idx);
        /// <summary>
        /// Get User field by alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        protected abstract IUserField OnGetFieldByAlias(string alias);
    }
}
