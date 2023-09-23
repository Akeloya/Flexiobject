using System;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс записи истории схемы изменения папок и связанных объектов
    /// </summary>
    public interface ISchemaHistoryItem : IBase
    {
        /// <summary>
        /// Дата события
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// Тип события
        /// </summary>
        FlexiSchemaEventTypes Type { get; }
        /// <summary>
        /// Ид записи в базе связанного объекта
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// Пользовательское имя
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Ид связанного удалённого объекта
        /// </summary>
        int DeletedRef { get; }
        /// <summary>
        /// Старое название объекта
        /// </summary>
        string OldName { get; }
        /// <summary>
        /// Новое название объекта
        /// </summary>
        string NewName { get; }
        /// <summary>
        /// Действие над объектом
        /// </summary>
        FlexiSchemaActionTypes Action { get; }
        /// <summary>
        /// Версия сервера приложений во время изменения объекта
        /// </summary>
        string Version { get; }
        /// <summary>
        /// Сетевой адрес компьютера с клиентом, с которого производились изменения
        /// </summary>
        string IPAddress { get; }
    }
}
