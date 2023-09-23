namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPictures : IBase
    {
        /// <summary>
        /// Добавление новой картинки в коллекцию.
        /// </summary>
        /// <returns></returns>
        IPicture Add();
        /// <summary>
        /// Доступ к картинке по индексу
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        IPicture this[int idx] { get; }
        /// <summary>
        /// Количество картинок
        /// </summary>
        /// <returns></returns>
        int Count { get; }
        /// <summary>
        /// Удаление картинки по индексу
        /// </summary>
        /// <param name="idx"></param>
        void Remove(int idx);
    }
}