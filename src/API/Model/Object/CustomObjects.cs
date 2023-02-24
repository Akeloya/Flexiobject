using FlexiObject.Core.Interfaces;

namespace FlexiObject.API.Model
{
    public abstract class CustomObjects: AppBase, ICustomObjects
    {
        protected CustomObjects(Application app, object parent) : base(app, parent)
        {

        }

        public ICustomObject this[int index] => throw new System.NotImplementedException();

        public ICustomObject this[string name] => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public ICustomObject Add()
        {
            throw new System.NotImplementedException();
        }

        public void AddExisting(ICustomObject request)
        {
            throw new System.NotImplementedException();
        }

        public void AddExistingById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ICustomObject obj)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveExisting(object variant)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveExistingById(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Restore(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
