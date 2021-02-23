using CliFx;
using CliFx.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppServer.Services.CommandInterface
{
    [Command("srv run", Description = "Starts server")]
    public class ServerRun : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            throw new NotImplementedException();
        }
    }
}
