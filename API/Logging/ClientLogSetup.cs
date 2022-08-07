using CoaApp.Core.Logging;

namespace Flexiobject.API.Logging
{
    internal class ClientLogSetup : AlogSetuper
    {
        public override bool HasConsoleLog => false;
        public override bool HasNetworkLog => true;
    }
}
