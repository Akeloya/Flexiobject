namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Транзакция перевода состояния
    /// </summary>
    public interface IStateTransitions : IBase
    {
        /// <summary>
        /// Добавление транзакции в коллекцию
        /// </summary>
        /// <param name="state"></param>
        void Add(IStateTransition state);
        /// <summary>
        /// Создание транзакции перевода
        /// </summary>
        /// <returns></returns>
        IStateTransition CreateStateTransition();
        /// <summary>
        /// Удаление транзакции по идентификатору
        /// </summary>
        /// <param name="idx"></param>
        void Remove(int idx);
        /// <summary>
        /// Удаление указанной транзакции
        /// </summary>
        /// <param name="transition"></param>
        void Remove(IStateTransition transition);
        /// <summary>
        /// Удаление транзакции по ключу
        /// </summary>
        /// <param name="name"></param>
        void RemoveByName(string name);
        /// <summary>
        /// Количество транзакций в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к транзакции по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        IStateTransition this[int idx] { get; }
        /// <summary>
        /// Доступ к транзакции по алиасу
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        IStateTransition this[string alias] { get; }
    }
}