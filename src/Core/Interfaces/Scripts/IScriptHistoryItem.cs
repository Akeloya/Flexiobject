using System;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Элемент записи истории
    /// </summary>
    public interface IScriptHistoryItem : IBase
    {
        /// <summary>
        /// Дата последнего изменения
        /// </summary>
        DateTime Modified { get; }
        /// <summary>
        /// Дата создания
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// Текст скрипта
        /// </summary>
        string Script { get; }
        /// <summary>
        /// Флаг факта публикации. Допускается только одно значение "истина" среди записей в истории
        /// </summary>
        bool IsPublished { get; }
        /// <summary>
        /// Дата публикации
        /// </summary>
        DateTime PublishedDate { get; }
        /// <summary>
        /// Кем опубликованно
        /// </summary>
        IUser PublishedBy { get; }
        /// <summary>
        /// Кем создано
        /// </summary>
        IUser CreatedBy { get; }
        /// <summary>
        /// Кем изменено
        /// </summary>
        IUser ModifiedBy { get; }
    }
}
