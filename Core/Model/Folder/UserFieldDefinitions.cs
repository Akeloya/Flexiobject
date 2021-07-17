using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;

namespace CoaApp.Core.Folder
{
    ///<inheritdoc/>
    public abstract class UserFieldDefinitions: AppBase, IUserFieldDefinitions
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="app"></param>
        /// <param name="parent"></param>
        /// <param name="isContainer">Flag only for collection, wich belong to parent folder in app</param>
        protected UserFieldDefinitions(IApplication app, object parent, bool isContainer = false): base(app, parent)
        {
            IsContainer = isContainer;
        }
        ///<inheritdoc/>
        public bool IsContainer { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition this[int index] { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition this[string name] { get; }
        ///<inheritdoc/>
        public abstract int Count { get; }
        ///<inheritdoc/>
        public abstract IUserFieldDefinition Add(CoaFieldTypes type);
        ///<inheritdoc/>
        public abstract IUserFieldDefinition Add();
        ///<inheritdoc/>
        public abstract void AddExisting(IUserFieldDefinition field);
        ///<inheritdoc/>
        public abstract void Remove(IUserFieldDefinition obj);
        ///<inheritdoc/>
        public abstract void Remove(int index);
        ///<inheritdoc/>
        public abstract void RemoveExisting(IUserFieldDefinition field);
    }
}
