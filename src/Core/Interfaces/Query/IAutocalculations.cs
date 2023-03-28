namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция автокалькуляций для папки
    /// </summary>
    public interface IAutocalculations : IBase
    {
        /// <summary>
        /// Добавить новую автокалькуляцию
        /// </summary>
        /// <returns>Объект автокалькуляции</returns>
        IAutocalculation Add();
        /// <summary>
        /// Удалить автокалькуляцию
        /// </summary>
        /// <param name="variant">Объект IAutocalculation для удаления из текущей коллекции или индекс удаляемой калькуляции из коллекции </param>
        void Delete(object variant);
        /// <summary>
        /// Доступ к объекту коллекции по индексу
        /// </summary>
        /// <param name="idx">0..Count-1</param>
        /// <returns></returns>
        IAutocalculation this[int idx] { get; }
        /// <summary>
        /// Доступ к объекту коллекции по названию
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IAutocalculation this[string name] { get; }
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
    }
}