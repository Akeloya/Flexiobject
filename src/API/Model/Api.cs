using FlexiObject.API.Settings;
using FlexiObject.Core.Interfaces;

using Ninject;

namespace FlexiObject.API.Model
{
    public class Api
    {
        private static readonly IKernel kernel = new StandardKernel();
        public Api()
        {
        }

        public IApplication Create(bool standalone = false)
        {
            var bindings = new ApiBindings(standalone);
            kernel.Load(bindings);
            return kernel.Get<IApplication>();
        }
    }
}
