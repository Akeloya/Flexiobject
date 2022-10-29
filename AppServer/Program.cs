/*
 *  "Flexiobject server"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Flexiobject".
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using FlexiObject.Core.Config;
using FlexiObject.Core.Logging;

using FlexiObject.AppServer.Model;
using FlexiObject.AppServer.Settings;
using FlexiObject.Core;

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
            var application = Kernel.Get<CoaApplication>();            

            try
            {
                using var cts = new CancellationTokenSource();
                application.Start(cts.Token);

                var consoleWorker = Kernel.Get<ConsoleWorker>();
                consoleWorker.Execute(cts.Token, ()=> cts.Cancel());

                var logger = Kernel.Get<ILogger>();
                while (!cts.Token.IsCancellationRequested)
                {
                    Thread.Sleep(60000);
                    logger.Info("Server is alive");
                }

                application.Stop();
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
            Bind<Application>().To<CoaApplication>().InSingletonScope();
            Bind<ConsoleWorker>().ToSelf();
            Rebind<AlogSetuper>().To<ServerLogSetup>().InSingletonScope();
            Bind<ObjectFactory>().ToSelf().InSingletonScope();
        }
    }
}
