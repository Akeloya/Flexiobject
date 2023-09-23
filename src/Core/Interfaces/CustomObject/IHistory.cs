namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// История изменений объекта
    /// </summary>
    public interface IHistory : IBase
    {
        /// <summary>
        /// Количество изменений
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к элементу коллекции по индексу
        /// </summary>
        /// <param name="idx">0...Count-1 значение индекса</param>
        /// <returns></returns>
        IHistoryRecord this[int idx] { get; }
        //List<IHistoryItem> Items { get; }
    }
}