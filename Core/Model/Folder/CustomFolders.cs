using CoaApp.Core.Interfaces;

namespace CoaApp.Core.Folder
{
    ///<inheritdoc/>
    public abstract class CustomFolders: AppBase, ICustomFolders
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        protected CustomFolders(IApplication app, object parent) : base(app, parent)
        {

        }
        ///<inheritdoc/>
        public abstract ICustomFolder this[int index] { get; }
        ///<inheritdoc/>
        public abstract ICustomFolder this[string alias] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        public abstract ICustomFolder Add(string name, string alias, ICustomFolder parentFolder);
        ///<inheritdoc/>
        public abstract void Remove(int id, bool force = false);
        ///<inheritdoc/>
        public abstract void Remove(ICustomFolder folder, bool force = false);
    }
}
