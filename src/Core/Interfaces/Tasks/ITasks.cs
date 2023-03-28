namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Доступ к коллекции запланированных задач
    /// </summary>
    public interface ITasks : IBase
    {
        /// <summary>
        /// Добавление новой запланированной задачи
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ITask Add(short type);
        /// <summary>
        /// Удаление задания
        /// </summary>
        /// <param name="variant">Удаляемый объект или индекс 0...Count-1</param>
        void Remove(object variant);
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">0..Count-1 индекс коллекции</param>
        /// <returns>ITask объект коллекции</returns>
        ITask this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции по ITask.Alias
        /// </summary>
        /// <param name="alias">Строка-алиас запланированной задачи</param>
        /// <returns>ITask объект коллекции</returns>
        ITask this[string alias] { get; }
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
    }
}