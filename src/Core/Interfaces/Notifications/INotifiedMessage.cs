using System;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Сообщение уведомления пользователя
    /// </summary>
    public interface INotifiedMessage : IBase
    {
        /// <summary>
        /// Текст сообщения
        /// </summary>
        string Message { get;}
        /// <summary>
        /// Связанный объект
        /// </summary>
        ICustomObject LinkedRequest {get;}
        /// <summary>
        /// Дата-время события
        /// </summary>
        DateTime EventDate { get; }
        /// <summary>
        /// Отправитель
        /// </summary>
        IUser Sender { get; }
        /// <summary>
        /// Флаг прочитано ли сообщение
        /// </summary>
        bool IsReaded { get; }
        /// <summary>
        /// Дата прочтения сообщения
        /// </summary>
        DateTime? ReadedDate { get; }
        /// <summary>
        /// Прочитать сообщение
        /// </summary>
        void Read();
        /// <summary>
        /// Удалить сообщение
        /// </summary>
        void Delete();
    }
}
