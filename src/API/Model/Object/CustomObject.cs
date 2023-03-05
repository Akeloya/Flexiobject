using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;

namespace FlexiObject.API.Model
{
    public class CustomObject: AppBase, ICustomObject
    {
        protected CustomObject(Application app, object parent) : base(app, parent)
        {

        }

        public long UniqueId => throw new System.NotImplementedException();

        public string Name => throw new System.NotImplementedException();

        public IUserFields UserFields => throw new System.NotImplementedException();

        public IHistory History => throw new System.NotImplementedException();

        public ICustomFolder RequestFolder => throw new System.NotImplementedException();

        public bool IsModified => throw new System.NotImplementedException();

        public void Delete(bool skipTrashbin = false, bool ignoreReferences = false, FlexiDeletionObjectFlags? flags = null)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
