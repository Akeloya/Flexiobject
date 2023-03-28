namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция полей объекта IRequest
    /// <seealso cref="ICustomObject"/>
    /// </summary>
    public interface IUserFields : IBase
    {
        /// <summary>
        /// Количество объектов в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к полю по индексу в списке
        /// </summary>
        /// <param name="idx">0 - Count-1</param>
        /// <returns>IUserField объект <seealso cref="IUserField"/></returns>
        IUserField this[int idx] { get; }
        /// <summary>
        /// Доступ к объекту в коллекции по алиасу
        /// </summary>
        /// <param name="alias">Строка - алиас поля</param>
        /// <returns>IUserField объект <seealso cref="IUserField"/></returns>
        IUserField this[string alias] { get; }
    }
}