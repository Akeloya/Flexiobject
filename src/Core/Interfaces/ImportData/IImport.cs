namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Импорт данных
    /// </summary>
    public interface IImport : IBase
    {
        /// <summary>
        /// Запуск импорта данных
        /// </summary>
        void Run(object settings);
        /// <summary>
        /// Путь к файлу, содержащему лог импорта
        /// </summary>
        string LogFile { get; }
        /// <summary>
        /// Источник данных
        /// </summary>
        string DataSource { get; set; }
    }
}