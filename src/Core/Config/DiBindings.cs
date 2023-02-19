using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Logging;

using Ninject.Modules;

using System.Reflection;

namespace FlexiObject.Core.Config
{
    public class DiBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IContainer>().To<Container>().InSingletonScope();
            Bind<LoggerFactory>().ToSelf().InSingletonScope();
            Bind<IJsonSettingsStore>().To<JsonSettingsStore>();
            Bind<ILogger>().ToMethod((context) =>
            {
                var factory = Kernel.GetService(typeof(LoggerFactory)) as LoggerFactory;
                return factory.Create(context.Request?.ParentRequest?.Target.Name ?? Assembly.GetExecutingAssembly().GetName().Name);
            });
            Bind<AlogSetuper>().To<LogDefaultSetuper>().InSingletonScope();

            Bind<IApplication>().To<Application>().InSingletonScope();
            Bind<ISession>().To<Session>();
        }
    }
}
