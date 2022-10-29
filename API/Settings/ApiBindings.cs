
using FlexiObject.API.Logging;
using FlexiObject.API.Transport;
using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;

namespace FlexiObject.API.Settings
{
    internal class ApiBindings : DiBindings
    {
        public override void Load()
        {
            base.Load();
            Kernel.Rebind<AlogSetuper>().To<ClientLogSetup>().InSingletonScope();
            Kernel.Bind<Client>().ToMethod((ctx) => Client.Factory.GetSinglton());
        }
    }
}
