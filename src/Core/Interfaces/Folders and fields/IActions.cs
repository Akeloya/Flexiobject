namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс коллекции действий модификации объектов
    /// </summary>
    public interface IActions : IBase
    {
        /// <summary>
        /// Добавить новое действие
        /// </summary>
        /// <returns></returns>
        IAction Add();
        /// <summary>
        /// Удалить действие
        /// </summary>
        /// <param name="variant"></param>
        void Remove(object variant);
        /// <summary>
        /// Количество действий в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к действию по индексу
        /// </summary>
        /// <param name="idx">0...Count-1 индекс действия</param>
        /// <returns></returns>
        IAction this[int idx] { get; }
        /// <summary>
        /// Изменение порядка действий при обработке
        /// </summary>
        /// <param name="left">Объект IAction или индекс 0...Count-1 коллекции</param>
        /// <param name="right">Объект IAction или индекс 0...Count-1 коллекции</param>
        void Swap(object left, object right);
    }
}