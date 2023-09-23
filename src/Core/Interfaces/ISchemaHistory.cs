namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс доступа к истории изменения схемы сервера
    /// </summary>
    public interface ISchemaHistory : IBase
    {
        /// <summary>
        /// Получение записи изменения схемы истории по её индексу
        /// </summary>
        /// <param name="idx">0..Count-1 значение индекса</param>
        /// <returns>Объект записи истории</returns>
        ISchemaHistoryItem this[int idx] { get; }
        /// <summary>
        /// Количество записей истории в коллекции
        /// </summary>
        int Count { get; }
    }
}
