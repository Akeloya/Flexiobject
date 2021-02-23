/*
 *  "Custom object application server"
 *  Application for creating and using freely customizable configuration of data, forms, actions and other things
 *  Copyright (C) 2020 by Maxim V. Yugov.
 *
 *  This file is part of "Custom object application".
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

using AppServer.Services.CommandInterface;
using CliFx;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AppServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

#if Linux || OSX
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
#endif
#if Windows
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggerFactory => loggerFactory.AddEventLog())
                .UseWindowsService()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {                                        
                    if(args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<DatabaseInfo>();
                    services.AddTransient<DatabaseCheck>();
                    services.AddTransient<DatabaseClear>();
                    services.AddTransient<DatabaseInit>();
                    services.AddTransient<DatabaseSetConfig>();
                    
                    var serviceProvider = services.BuildServiceProvider();

                    new CliApplicationBuilder()
                        .AddCommandsFromThisAssembly()
                        .UseTypeActivator(serviceProvider.GetService)
                        .Build()
                        .RunAsync();
                });
#endif
    }
}
