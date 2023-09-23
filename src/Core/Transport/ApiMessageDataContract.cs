using System;

namespace FlexiObject.Core.Transport
{
    [Serializable]
    public class ApiMessageDataContract
    {
        public StateOfChange State { get; set; }
        public ChangedObject ChangedObject { get; set; }
        public int SessionId { get; set; }
        public object ObjectId { get; set; }
        public NotifiedMessageDataContract NotifiedMessage { get; set; }
    }
    [Serializable]
    public enum StateOfChange
    {
        Add,
        Update,
        Remove,
        Notify
    }
    [Serializable]
    public enum ChangedObject
    {
        Field,
        Folder,
        SyncLinkedFields,
        None
    }

    [Serializable]
    public class NotifiedMessageDataContract
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public long LinkedRequest { get; set; }

        public DateTime EventDate { get; set; }

        public long Sender { get; set; }

        public bool IsReaded { get; set; }

        public DateTime? ReadedDate { get; set; }
    }
}
