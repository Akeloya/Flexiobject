namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Связь полей
    /// </summary>
    public interface IFieldMappings : IBase
    {
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">0...Count-1 индекс коллекции</param>
        /// <returns>IFieldMapping объект</returns>
        IFieldMapping this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции по алиасу источника поля
        /// </summary>
        /// <param name="source">Алиас источника поля</param>
        /// <returns></returns>
        IFieldMapping this[string source] { get; }
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
    }
}