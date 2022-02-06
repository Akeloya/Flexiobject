using CoaApp.Core.Interfaces;
using System;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class Users : AppBase, IUsers
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected Users(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract IUser this[int index] { get; }
        ///<inheritdoc/>
        public abstract IUser this[string name] { get; }
        ///<inheritdoc/>
        public int Count => throw new NotImplementedException();
        ///<inheritdoc/>
        public abstract IUser Add();
        ///<inheritdoc/>
        public abstract IUser GetUserByLoginName(string login);
        ///<inheritdoc/>
        public abstract void Remove(IUser obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
     }
}
