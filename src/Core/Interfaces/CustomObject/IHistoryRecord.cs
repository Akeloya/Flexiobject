using System;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Запись в истории объекта
    /// </summary>
    public interface IHistoryRecord : IBase
    {
        /// <summary>
        /// Действие
        /// </summary>
        FlexiHistoryActionTypes Action { get; }
        /// <summary>
        /// Дата-время изменения
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// текстовое описание события
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Новое значение
        /// </summary>
        string NewValue { get; }
        /// <summary>
        /// Старое значение
        /// </summary>
        string OldValue { get; }
        /// <summary>
        /// Информация о состоянии объекта в момент изменения
        /// </summary>
        IState State { get; }
        /// <summary>
        /// Пользователь, вызвавший изменения
        /// </summary>
        IUser User { get;}
        /// <summary>
        /// Поле, которое было изменено.
        /// </summary>
        IUserFieldDefinition UserField { get; }
        /// <summary>
        /// Имя пользователя IUser.Object.Name
        /// </summary>
        string UserName { get; }
    }
}