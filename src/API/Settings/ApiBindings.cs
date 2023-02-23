
using FlexiObject.API.Logging;
using FlexiObject.API.Repositories;
using FlexiObject.API.Transport;
using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Repository;

namespace FlexiObject.API.Settings
{
    public class ApiBindings : DiBindings
    {
        private readonly bool _standalone;
        public ApiBindings(bool standalone)
        {
            _standalone = standalone;
        }
        public override void Load()
        {
            base.Load();
            Rebind<AlogSetuper>().To<ClientLogSetup>().InSingletonScope();

            if(!_standalone)
            {
                Bind<Client>().ToMethod((ctx) => Client.Factory.GetSinglton());
                Rebind<ISessionRepository>().To<ClientSessionRepository>().InSingletonScope();
            }
        }
    }
}
