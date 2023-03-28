namespace FlexiObject.Core.Interfaces
{
   /// <summary>
   /// Активная сессия
   /// </summary>
    public interface IActiveSessions : IBase
    {
        /// <summary>
        /// Доступ к сессии по индексу в списке
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        IActiveSession this[int idx] { get; }
        /// <summary>
        /// Количество активных сессий пользователей
        /// </summary>
        int Count { get; }
    }
}