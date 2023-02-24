using FlexiObject.Core.Enumes;
using FlexiObject.Core.Interfaces;
using System;

namespace FlexiObject.API.Model.Folder
{
    public abstract class UserFieldDefinitions<T>: AppBase, IUserFieldDefinitions
    {
        protected UserFieldDefinitions(Application app, object parent): base(app, parent)
        {

        }

        public IUserFieldDefinition this[int index] => throw new NotImplementedException();

        public IUserFieldDefinition this[string name] => throw new NotImplementedException();

        public bool IsContainer => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IUserFieldDefinition Add(CoaFieldTypes type)
        {
            throw new NotImplementedException();
        }

        public void AddExisting(IUserFieldDefinition field)
        {
            throw new NotImplementedException();
        }

        public void Delete(object variant)
        {
            throw new NotImplementedException();
        }

        public void RemoveExisting(IUserFieldDefinition field)
        {
            throw new NotImplementedException();
        }
    }
}
