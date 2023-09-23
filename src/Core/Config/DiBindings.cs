using FlexiObject.Core.Logging;

using Ninject.Modules;

using System.Collections.Generic;
using System;
using System.Reflection;
using FlexiObject.Core.Repository;
using System.Linq;
using FlexiObject.Core.Config.SettingsStore;

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

            LoadRepositories();
        }

        protected virtual void LoadRepositories()
        {
            var repoImplementations = GetTypesWithHelpAttribute<RepositoryAttribute>(Assembly.GetAssembly(GetType()));
            foreach (var repo in repoImplementations)
            {
                if(repo.WithRebind)
                    Kernel.Rebind(repo.Type).To(repo.TargetType).InSingletonScope();
                else
                    Kernel.Bind(repo.Type).To(repo.TargetType).InSingletonScope();
            }
        }

        protected IEnumerable<T> GetTypesWithHelpAttribute<T>(Assembly assembly) 
        {
            foreach(Type type in assembly.GetTypes()) 
            {
                var attributes = type.GetCustomAttributes(typeof(T), true);
                if (attributes.Length > 0) 
                {
                    yield return (T)attributes.First();
                }
            }
        }
    }
}
