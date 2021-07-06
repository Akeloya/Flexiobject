/*
 *  "Custom object application core"
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
using AppServer.Model;
using AppServer.Properties;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AppServer.Services
{
    internal class ConsoleWorker
    {
        private readonly string[] _allowedCommands = { "-close", "-help", "-show", "-run", "-clear" };
        private readonly string[] _allowesShowParams = { "w", "c" };
        private readonly string[] _commandStart;
        private const char _separator = ' ';
        private readonly CoaApplication _application;
        public ConsoleWorker(CoaApplication app, string[] commandStart)
        {
            /*if (commandStart != null && commandStart.Length == 0)
                throw new ArgumentNullException(nameof(commandStart));*/
            _commandStart = commandStart;
            _application = app;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Assembly assembly = Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.ConsoleStartInfo, fvi.ProductName, fvi.ProductVersion, fvi.LegalCopyright));
            Console.ResetColor();
        }

        public void ExecuteConsoleWorker()
        {
            string command = string.Empty;
            if (_commandStart.Length > 0)
                command = _commandStart[0];
            bool exite = false;
            while (!exite)
            {
                if (command.StartsWith("-run", StringComparison.OrdinalIgnoreCase))
                {
                    RunServer();
                }
                else if (command.StartsWith("-show", StringComparison.OrdinalIgnoreCase))
                    ExecuteShowCommand(command);
                else if (command.StartsWith("-help", StringComparison.OrdinalIgnoreCase))
                    ExecuteHelpCommand(command);
                else if (command.StartsWith("-clear", StringComparison.OrdinalIgnoreCase))
                    Console.Clear();

                if (!Console.KeyAvailable)
                {
                    Thread.Sleep(200);
                    command = string.Empty;
                    continue;
                }
                else
                {
                    command = Console.ReadLine();
                }

                if (command.StartsWith("-close", StringComparison.OrdinalIgnoreCase))
                {
                    exite = true;
                    _application.ShutdownServer();
                    continue;
                }
            }
        }

        private void ExecuteShowCommand(string fullCommandLine)
        {
            string[] args = GetCommandArgs(fullCommandLine);
            if (args.Length == 1)
                ExecuteHelpCommand("-help");
        }

        private void ExecuteHelpCommand(string fullCommandLine)
        {
            string[] args = GetCommandArgs(fullCommandLine);
            if (args.Length == 1)
            {
                Console.WriteLine("Allowed commands:");
                foreach (string comand in _allowedCommands)
                {
                    Console.WriteLine(comand);
                }
            }
        }

        private string[] GetCommandArgs(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException(nameof(command));
            return command.Split(new char[] { _separator });
        }

        private async void RunServer()
        {
            Task task = new Task(() =>
            {
                Console.WriteLine("Initiating server data...");
                _application.Initiate();
                Console.WriteLine("Server data initiated");
                Console.WriteLine("Starting server...");
                _application.Start();
                Console.WriteLine("Server started.");
            });
            task.Start(TaskScheduler.Default);
            await task.ConfigureAwait(false);
        }
    }

}
