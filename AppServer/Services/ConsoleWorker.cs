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
