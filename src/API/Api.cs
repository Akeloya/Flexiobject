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
        private readonly bool _standalone;
        public Api(bool standalone = false)
        {
            _standalone = standalone;
            var bindings = new ApiBindings(standalone);
            kernel.Load(bindings);
        }

        public IApplication Create()
        {
            if(_standalone)
            {
                var contextFactory = kernel.Get<DbContextFactory>();
                var context = contextFactory.Create();

            
                var result = context.Database.EnsureCreated();
                if(!result)
                {
                    //TODO: убедиться что к БД есть подключение, она создана
                    if(context.Database.IsInMemory())
                    {
                        context.AppUsers.Add(new DbProvider.Entities.AppUser
                        {
                            LoginMode = Core.Enumes.CoaUserAuthTypes.Internal,
                            LoginName = Environment.UserName,
                            Password = Environment.UserName,
                            DisplayName = Environment.UserName,
                            IsActive = true,
                            IsGroup = false,
                            IsAdministrator = true,
                        });
                        context.SaveChanges();
                    }                    
                }
            }
            return kernel.Get<IApplication>();
        }

        public void Dispose()
        {
            kernel.Dispose();
        }
    }
}
