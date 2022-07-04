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

using CoaApp.Core.Config;

using Ninject;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Flexiobject.AppServer
{
    public class Program
    {
        private static IKernel Kernel;
        public static void Main(string[] args)
        {
            Kernel = new StandardKernel();
            var bindings = new ServerBindings();
            Kernel.Load(bindings);

            Worker worker = Kernel.Get<Worker>();
            var cts = new CancellationTokenSource();

            var sr = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.log"));
            Console.SetOut(sr);
            try
            {
                Task.Factory.StartNew(() => worker.ExecuteAsync(cts.Token)).Wait();
            }
            finally
            {
                sr.Close();
                Kernel.Dispose();
            }
        }
    }

    public class ServerBindings : DiBindings
    {
        public override void Load()
        {
            Kernel.Bind<Worker>().ToSelf();
            base.Load();
        }
    }
}
