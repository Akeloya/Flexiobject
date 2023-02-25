using FlexiObject.API.Settings;
using FlexiObject.Core.Interfaces;

using FlexiOject.DbProvider;

using Microsoft.EntityFrameworkCore;

using Ninject;

using System;

namespace FlexiObject.API
{
    public class Api : IDisposable
    {
        private readonly IKernel kernel = new StandardKernel();
        public Api(bool standalone = false)
        {
            var bindings = new ApiBindings(standalone);
            kernel.Load(bindings);
        }

        public IApplication Create()
        {
            var contextFactory = kernel.Get<DbContextFactory>();
            var context = contextFactory.Create();

            //if(context.Database.IsInMemory())
            context.Database.EnsureCreated();
            //TODO: убедиться что к БД есть подключение, она создана
            var sqlCreateScript = context.Database.GenerateCreateScript();
            context.Database.ExecuteSqlRaw(sqlCreateScript);

            return kernel.Get<IApplication>();
        }

        public void Dispose()
        {
            kernel.Dispose();
        }
    }
}
