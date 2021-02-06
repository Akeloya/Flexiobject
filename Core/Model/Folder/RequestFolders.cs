using CoaApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoaApp.Core.Model.Folder
{
    public abstract class RequestFolders<T>: AppBase<T>, IRequestFolders
    {
        protected RequestFolders(Application app, T parent) : base(app, parent)
        {

        }

        public IRequestFolder this[int index] => throw new NotImplementedException();

        public IRequestFolder this[string name] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IRequestFolder Add(string name, string alias, IRequestFolder parentFolder)
        {
            throw new NotImplementedException();
        }

        public IRequestFolder Add()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, bool force = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(IRequestFolder folder, bool force = false)
        {
            throw new NotImplementedException();
        }

        public void Remove(IRequestFolder obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
