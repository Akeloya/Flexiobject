namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция визуальных представлений
    /// </summary>
    public interface IViews : IBase
    {
        /// <summary>
        /// Получение представления по индексу
        /// </summary>
        /// <param name="idx">0..Count-1</param>
        /// <returns>IView объект</returns>
        IView this[int idx] { get; }
        /// <summary>
        /// Количество элементов в коллекции
        /// </summary>
        int Count { get; }
    }
}
