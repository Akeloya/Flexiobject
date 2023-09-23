using FlexiObject.Core.Logging;

namespace FlexiObject.API.Logging
{
    internal class ClientLogSetup : AlogSetuper
    {
        public override bool HasConsoleLog => false;
        public override bool HasNetworkLog => true;
    }
}
