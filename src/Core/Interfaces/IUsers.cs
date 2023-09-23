namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция пользователей приложения
    /// </summary>
    public interface IUsers : IBaseCollection<IUser>
    {
        /// <summary>
        /// Получить существующего пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <returns>Объект IUser</returns>
        IUser GetUserByLoginName(string login);
    }
}