using CoaApp.Core.Enumes;
using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoaApp.Core.Folder
{
    public abstract class UserFieldDefinitions: AppBase, IUserFieldDefinitions
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
