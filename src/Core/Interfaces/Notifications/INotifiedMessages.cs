namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция сообщений
    /// </summary>
    public interface INotifiedMessages : IBase
    {
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">0...Count-1 значение индекса</param>
        /// <returns></returns>
        INotifiedMessage this[int idx] { get; }
        /// <summary>
        /// Количество элементов коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Прочитать все сообщения
        /// </summary>
        void ReadAll();
        /// <summary>
        /// Очистить все сообщения
        /// </summary>
        void Clear();
        /// <summary>
        /// Создать сообщение
        /// </summary>
        INotifiedMessage Create(IUser sender, string message, ICustomObject linkedObject);
        /// <summary>
        /// Получить новые или непрочитаныне сообщения
        /// </summary>
        /// <returns>Коллекция сообщений</returns>
        INotifiedMessages GetNewMessages();
    }
}
