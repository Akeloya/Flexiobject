using System;

namespace FlexiObject.Core.Config
{
    public class ServiceLocator
    {
        private static IContainer _container;
        internal ServiceLocator(IContainer container)
        {
            _container = container;
        }

        public static T Get<T>()
        {
            return _container.Get<T>();
        }

        public static object Get(Type type)
        {
            return _container.Get(type);
        }
    }
}
