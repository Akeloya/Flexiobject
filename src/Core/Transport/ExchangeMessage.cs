using System;

namespace FlexiObject.Core.Transport
{
    public class ExchangeMessage
    {
        public Guid MessageID { get; set; } = Guid.NewGuid();
        public Guid ClientUid { get; set; }
        public DateTime TimeSend { get; set; }
        public DateTime TimeRecieve { get; set; }
        public object Data { get; set; }
        public object[] Parameters { get; set; }
        public ExchangeMessage(ExchangeMessage msg)
        {
            ClientUid = msg.ClientUid;
            MessageID = msg.MessageID;
        }

        public ExchangeMessage()
        {

        }

    }
}
