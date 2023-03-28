namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция групп безопасности
    /// </summary>
    public interface IGroups : IBase
    {
        /// <summary>
        /// Добавление новой группы
        /// </summary>
        /// <returns>IGroup объект, добавленный в коллекцию</returns>
        IGroup Add();
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">Индекс 0...Count-1</param>
        /// <returns></returns>
        IGroup this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции по имени группы
        /// </summary>
        /// <param name="name">Имя группы</param>
        /// <returns></returns>
        IGroup this[string name] { get; }
        /// <summary>
        /// Получение элемента коллекции по
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        IGroup this[IGroup group] { get; }
    }
}
