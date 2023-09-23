﻿
using FlexiObject.API.DataLayer;
using FlexiObject.API.Logging;
using FlexiObject.API.Model;
using FlexiObject.API.Repositories;
using FlexiObject.API.Transport;
using FlexiObject.Core.Config;
using FlexiObject.Core.Interfaces;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Repository;
using FlexiObject.DbProvider;

using FlexiOject.DbProvider;

using Ninject;

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
            
            Bind<IApplication>().To<Application>().InSingletonScope();

            if(_standalone)
            {
                Bind<DbContextFactory>().To<StandaloneDbContextFactory>().InSingletonScope();
                Bind<AppDbContext>().ToConstant(Kernel.Get<DbContextFactory>().Create());
                Rebind<ISessionRepository>().To<StandaloneSessionRepository>().InSingletonScope();
            }
            else
            {
                Bind<Client>().ToSelf().InTransientScope();
            }
        }        
    }
}
