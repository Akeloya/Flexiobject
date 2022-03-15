﻿using Flexiobject.Core.Enumes;
using Flexiobject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flexiobject.Core.Folder
{
    public abstract class UserFieldDefinitions<T>: AppBase<T>, IUserFieldDefinitions
    {
        protected UserFieldDefinitions(Application app, T parent): base(app, parent)
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
