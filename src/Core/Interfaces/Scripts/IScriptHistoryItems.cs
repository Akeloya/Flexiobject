namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Данные истории изменения скриптов
    /// </summary>
    public interface IScriptHistoryItems : IBase
    {
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IScriptHistoryItem this[int index] { get; }
        /// <summary>
        /// Количество записей
        /// </summary>
        int Count { get; }
    }
}
