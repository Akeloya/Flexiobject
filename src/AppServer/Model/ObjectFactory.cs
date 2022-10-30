using System;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;

namespace FlexiObject.AppServer.Model
{
    class ObjectFactory
    {
        private readonly IContainer _conterner;
        
        public ObjectFactory(IContainer container)
        {
            _conterner = container;
        }
        public object GetByType(Type type)
        {
            if(type is IApplication)
                return _conterner.Get(type);
            throw new NotImplementedException();
        }
    }
}
