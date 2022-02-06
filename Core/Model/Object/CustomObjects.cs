using CoaApp.Core.Interfaces;

namespace CoaApp.Core
{
    ///<inheritdoc/>
    public abstract class CoaCustomObjects : AppBase, ICustomObjects
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected CoaCustomObjects(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract ICustomObject this[int index] { get; }
        ///<inheritdoc/>
        public abstract ICustomObject this[string name] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        protected internal bool IsModified { get; }
        ///<inheritdoc/>
        public abstract ICustomObject Add();
        ///<inheritdoc/>
        public abstract void AddExisting(ICustomObject obj);
        ///<inheritdoc/>
        public abstract void AddExistingById(long id);
        ///<inheritdoc/>
        public abstract void Delete(long id);
        ///<inheritdoc/>
        public abstract void Remove(ICustomObject obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
        ///<inheritdoc/>
        public abstract void RemoveExisting(object variant);
        ///<inheritdoc/>
        public abstract void RemoveExistingById(long id);
        ///<inheritdoc/>
        public abstract void Restore(long id);
    }
}
