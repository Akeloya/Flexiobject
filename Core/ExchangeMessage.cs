using CoaApp.Core.Errors;
using System;

namespace CoaApp.Core
{
    [Serializable]
#pragma warning disable CS1591 
    public class ExchangeMessage
    {
        public Guid MessageID { get; }
        public Guid ClientUid { get; set; }
        public string Method { get; set; }
        public int ThreadId { get; set; }
        public DateTime TimeSend { get; set; }
        public object Data { get; set; }
        public object[] Parameters { get; set; }
        public AppException Error { get; set; }
        public ExchangeMessage(ExchangeMessage msg)
        {
            ThreadId = msg.ThreadId;
            ClientUid = msg.ClientUid;
            Method = msg.Method;
            MessageID = msg.MessageID;
        }

        public ExchangeMessage()
        {
            MessageID = Guid.NewGuid();
        }
    }
#pragma warning restore CS1591 
}
