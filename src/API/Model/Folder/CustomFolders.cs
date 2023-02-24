﻿using FlexiObject.Core.Interfaces;
using System;

namespace FlexiObject.API.Model.Folder
{
    public abstract class CustomFolders<T>: AppBase, ICustomFolders
    {
        protected CustomFolders(Application app, object parent) : base(app, parent)
        {

        }

        public ICustomFolder this[int index] => throw new NotImplementedException();

        public ICustomFolder this[string name] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public ICustomFolder Add(string name, string alias, ICustomFolder parentFolder)
        {
            throw new NotImplementedException();
        }

        public ICustomFolder Add()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, bool force = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(ICustomFolder folder, bool force = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(ICustomFolder obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}