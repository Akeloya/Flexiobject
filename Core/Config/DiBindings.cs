using CoaApp.Core.Logging;

using Ninject.Modules;

using System.Reflection;

namespace CoaApp.Core.Config
{
    public class DiBindings : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<LoggerFactory>().ToSelf().InSingletonScope();
            Kernel.Bind<IJsonSettingsStore>().To<JsonSettingsStore>();
            Kernel.Bind<ILogger>().ToMethod((context) =>
            {
                var factory = Kernel.GetService(typeof(LoggerFactory)) as LoggerFactory;
                return factory.Create(context.Request?.ParentRequest?.Target.Name ?? Assembly.GetExecutingAssembly().GetName().Name);
            });
            Kernel.Bind<AlogSetuper>().To<LogDefaultSetuper>().InSingletonScope();
        }
    }
}
