namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс отображения данных в папке
    /// </summary>
    public interface IViewLayouts : IBase
    {
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; set; }
        /// <summary>
        /// Доступ к коллекции
        /// </summary>
        /// <param name="idx">0...Count-1</param>
        /// <returns>IViewLayout</returns>
        IViewLayout this[int idx] { get; }
    }
}