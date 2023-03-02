using System;

namespace FlexiObject.Core.Transport.DataContracts
{
    public class PingDataContract
    {
        public DateTime DateTime { get; set; }
        public string ServerInfo { get; set; }
        public string Version { get; set; }
    }
}
