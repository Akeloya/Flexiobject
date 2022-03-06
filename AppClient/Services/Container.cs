using Ninject;

using System;

namespace AppClient.Services
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
    }
}
