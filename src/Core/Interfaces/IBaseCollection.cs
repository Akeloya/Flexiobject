namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция форм и правил их отображения
    /// </summary>
    public interface IBaseCollection<T>
    {
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="index">0..Count-1 номер индекса</param>
        /// <returns></returns>
        T this[int index] { get; }
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="name">Имя объекта, если имеется</param>
        /// <returns></returns>
        T this[string name] { get; }
        /// <summary>
        /// Добавить 
        /// </summary>
        /// <returns>объект коллекции</returns>
        T Add();
        /// <summary>
        /// Удалить объект коллекции
        /// </summary>
        /// <param name="obj">объект, удаляемый из коллекции</param>
        void Remove(T obj);
        /// <summary>
        /// Удалить объект коллекции
        /// </summary>
        /// <param name="index">номер индекса, удаляемый из коллекции</param>
        void Remove(int index);
        /// <summary>
        /// Количество 
        /// </summary>
        int Count { get; }
    }
}
