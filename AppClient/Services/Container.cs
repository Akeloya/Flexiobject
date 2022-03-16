using Ninject;

using System;

namespace FlexiObject.AppClient.Services
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
            return _kernel.GetService(type);
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
