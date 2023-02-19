using Ninject;

using System;
using FlexiObject.Core.Config;

namespace FlexiObject.Core
{
    public class Container : IContainer
    {
        private readonly IKernel _kernel;

        public Container(IKernel kernel)
        {
            _kernel = kernel;
        }
        public T Get<T>()
        {
            return (T)_kernel.Get(typeof(T));
        }

        public object Get(Type type)
        {
            return _kernel.Get(type);
        }

        public object GetService(Type type)
        {
            return _kernel.GetService(type);
        }
        public T GetService<T>()
        {
            return (T)_kernel.GetService(typeof(T));
        }
        /// <summary>
        /// Get by type and convert to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public T Get<T>(Type type)
        {
            return (T)Get(type);
        }
    }
}
