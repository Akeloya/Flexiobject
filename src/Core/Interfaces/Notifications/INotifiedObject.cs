namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface INotifiedObject : IBase
    {
        /// <summary>
        /// Уведомить получателя о событии
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="linkedObject">Связанный объект</param>
        void Notify(string message, object linkedObject);
        /// <summary>
        /// Коллекция уведомлений пользователя
        /// </summary>
        /// <returns><seealso cref="INotifiedMessages"/> объект коллекции</returns>
        INotifiedMessages Messages { get; }
    }
}
