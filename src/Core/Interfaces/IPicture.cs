namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Интерфейс картинки, использующейся в интерфейсе приложения
    /// </summary>
    public interface IPicture : IBase
    {
        /// <summary>
        /// Ид картинки
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Двоичное содержимое
        /// </summary>
        byte[] Data { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void Save();
    }
}