using FlexiObject.Core.Interfaces;

namespace FlexiObject.API.Model
{
    public abstract class UserFields: AppBase, IUserFields
    {
        protected UserFields(Application app, object parent) : base(app, parent)
        {

        }

        public IUserField this[int idx] => OnGetFieldByIndex(idx);

        public IUserField this[string alias] => OnGetFieldByAlias(alias);

        public int Count => OnGetCount();
        /// <summary>
        /// Get User fields count
        /// </summary>
        /// <returns></returns>
        protected virtual int OnGetCount()
        {
            return 0;
        }
        /// <summary>
        /// Get User field by index
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        protected virtual IUserField OnGetFieldByIndex(int idx)
        {
            return null;
        }
        /// <summary>
        /// Get User field by alias
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        protected virtual IUserField OnGetFieldByAlias(string alias)
        {
            return null;
        }
    }
}
