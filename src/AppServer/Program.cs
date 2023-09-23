using FlexiObject.API.Settings;
using FlexiObject.AppServer.Controllers;
using FlexiObject.AppServer.Model;
using FlexiObject.AppServer.Repositories;
using FlexiObject.AppServer.Settings;
using FlexiObject.Core.Logging;
using FlexiObject.Core.Repository;
using FlexiObject.DbProvider;

using FlexiOject.DbProvider;

using Ninject;

using System.Threading;

namespace FlexiObject.AppServer
{
    public class Program
    {
        private static readonly IKernel Kernel = new StandardKernel();
        public static void Main(string[] args)
        {
            var bindings = new ServerBindings();
            Kernel.Load(bindings);

            var logSetuper = Kernel.Get<AlogSetuper>();
            logSetuper.Setup();
            var server = Kernel.Get<Server>();

            try
            {
                using var cts = new CancellationTokenSource();
                server.Start(cts.Token);

                var consoleWorker = Kernel.Get<ConsoleWorker>();
                consoleWorker.Execute(cts.Token, cts.Cancel);

                var logger = Kernel.Get<ILogger>();
                while (!cts.Token.IsCancellationRequested)
                {
                    Thread.Sleep(60000);
                    logger.Info("Server is alive");
                }
            }
            finally
            {
                Kernel.Dispose();
            }
        }
    }

    public class ServerBindings : ApiBindings
    {
        public ServerBindings() : base(false)
        {
        }

        public override void Load()
        {
            base.Load();

            Rebind<AppDbContext>().ToMethod((ctx)=> ctx.Kernel.Get<DbContextFactory>().Create()).InSingletonScope();
            Bind<ConsoleWorker>().ToSelf();
            Rebind<AlogSetuper>().To<ServerLogSetup>().InSingletonScope();

            Bind<DefaultController>().ToSelf().InSingletonScope();
            Bind<AppController>().ToSelf().InSingletonScope();
        }
    }
}
