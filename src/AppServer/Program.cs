using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;

using FlexiObject.AppServer.Model;
using FlexiObject.AppServer.Settings;

using Ninject;

using System.Threading;
using FlexiObject.Core.Repository;
using FlexiObject.AppServer.Repositories;

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

                server.Stop();
            }
            finally
            {
                Kernel.Dispose();
            }
        }
    }

    public class ServerBindings : DiBindings
    {
        public override void Load()
        {
            base.Load();

            Bind<ConsoleWorker>().ToSelf();
            Rebind<AlogSetuper>().To<ServerLogSetup>().InSingletonScope();
            Bind<ObjectFactory>().ToSelf().InSingletonScope();

            Rebind<ISessionRepository>().To<ServerSessionRepository>().InSingletonScope();
        }
    }
}
