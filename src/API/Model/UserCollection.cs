using FlexiObject.Core;
using FlexiObject.Core.Interfaces;

using System;

namespace FlexiObject.API.Model
{
    public abstract class Users : AppBase, IUsers
    {
        protected Users(Application app, object parent) : base(app, parent)
        {

        }
        public IUser this[int index] => throw new NotImplementedException();

        public IUser this[string name] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IUser Add()
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByLoginName(string login)
        {
            throw new NotImplementedException();
        }

        public void Remove(IUser obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int index)
        {
            throw new NotImplementedException();
        }
    }
}
