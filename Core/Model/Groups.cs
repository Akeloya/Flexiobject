using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class Groups : AppBase, IGroups
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected Groups(IApplication app, object parent): base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract IGroup this[int index] { get; }
        ///<inheritdoc/>
        public abstract IGroup this[string name] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        public abstract IGroup Add();
        ///<inheritdoc/>
        public abstract void Remove(IGroup obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
    }
}
