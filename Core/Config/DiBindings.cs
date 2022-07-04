using CoaApp.Core.Logging;

using Ninject.Modules;


namespace CoaApp.Core.Config
{
    public class DiBindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<LoggerFactory>().ToSelf().InSingletonScope();
            Kernel.Bind<IJsonSettingsStore>().To<JsonSettingsStore>();
        }
    }
}
