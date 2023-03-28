namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция настроек импорта данных
    /// </summary>
    public interface IImportDefinitions : IBase
    {
        /// <summary>
        /// Размер коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Доступ к элементу коллекции по индексу
        /// </summary>
        /// <param name="idx">Индекс коллекции 0...Count-1</param>
        /// <returns></returns>
        IImportDefinition this[int idx] { get; }
        /// <summary>
        /// Доступ к элементу коллекции по названию
        /// </summary>
        /// <param name="name">Название настройки</param>
        /// <returns></returns>
        IImportDefinition this[string name] { get; }
        /// <summary>
        /// Добавление новой настройки импорта данных
        /// </summary>
        /// <param name="folder">Папка для которой добавляется настройка импорта данных</param>
        /// <returns></returns>
        IImportDefinition Add(ICustomFolder folder);
        /// <summary>
        /// Удаление настройки импорта данных
        /// </summary>
        /// <param name="variant"></param>
        void Remove(object variant);
    }
}