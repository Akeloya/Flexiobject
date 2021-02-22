using System;

namespace CoaApp.Core
{
    [Serializable]
#pragma warning disable CS1591 // Отсутствует комментарий XML для открытого видимого типа или члена
    public class ApiMessage
    {
        public StateOfChange State { get; set; }
        public ChangedObject ChangedObject { get; set; }
        public int SessionId { get; set; }
        public object ObjectId { get; set; }
        public NotifiedMessageDataContract NotifiedMessage { get; set; }
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
    
#pragma warning restore CS1591
}
