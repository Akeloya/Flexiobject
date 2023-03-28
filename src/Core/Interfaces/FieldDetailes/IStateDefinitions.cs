namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Определение коллекции состояний рабочего процесса
    /// </summary>
    public interface IStateDefinitions : IBase
    {
        /// <summary>
        /// Создать состояние
        /// </summary>
        /// <returns>Новое состояние не привязанное к коллекции</returns>
        IState CreateStateDefinition();
        /// <summary>
        /// Добавить созданное состояние
        /// </summary>
        /// <param name="state">Состояние</param>
        void Add(IState state);
        /// <summary>
        /// Начальное состояние
        /// </summary>
        IState InitialState { get; }
        /// <summary>
        /// Удалить состояние по индексу
        /// </summary>
        /// <param name="idx"></param>
        void Remove(int idx);
        /// <summary>
        /// Удалить состояние
        /// </summary>
        /// <param name="state">Состояние в коллекции, которое требуется удалить</param>
        void Remove(IState state);
        /// <summary>
        /// Доступ к коллекции состояний по индексу
        /// </summary>
        /// <param name="idx">Индекс 0..Count-1 коллекции состояний</param>
        /// <returns>IState объект коллекции</returns>
        IState this[int idx] { get; }
        /// <summary>
        /// Доступ к коллекции состояний по алиасу
        /// </summary>
        /// <param name="alias">Алиас состояния из коллекции</param>
        /// <returns>IState объект коллекции</returns>
        IState this[string alias] { get; }
        /// <summary>
        /// Количество состояий в коллекции
        /// </summary>
        int Count { get; }
    }
}