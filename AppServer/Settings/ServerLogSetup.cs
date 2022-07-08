using CoaApp.Core.Logging;

namespace Flexiobject.AppServer.Settings
{
    internal class ServerLogSetup : AlogSetuper
    {
        public override bool HasConsoleLog => true;
        public override bool HasNetworkLog => true;
    }
}
