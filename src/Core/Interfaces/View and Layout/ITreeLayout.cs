namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Вывод объектов в виде дерева
    /// </summary>
    public interface ITreeLayout : IBase
    {
        /// <summary>
        /// Добавление уровня
        /// </summary>
        /// <param name="ufd"></param>
        void AppendLevel(int ufd);
        /// <summary>
        /// Очистка представления
        /// </summary>
        void Clear();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idx"></param>
        /// <returns>ID поля</returns>
        int GetLevel(int idx);
    }
}