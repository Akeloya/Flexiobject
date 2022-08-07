using CoaApp.Core.Config;
using CoaApp.Core.Logging;

using Flexiobject.API.Logging;
using Flexiobject.API.Transport;

namespace Flexiobject.API.Settings
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
