using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Представление настроек отображение списка объектов
    /// </summary>
    public interface IColumnLayout : IBase
    {
        /// <summary>
        /// Количество колонок в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Добавление новой колонки
        /// </summary>
        /// <param name="type">Тип колонки</param>
        /// <param name="field">Путь к полю</param>
        /// <param name="width">Визуальная ширина</param>
        /// <param name="header">Название</param>
        void AddColumn(FlexiColumnType type, string field, int width, string header);
        /// <summary>
        /// Получить поле колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        string GetColumnField(int index);
        /// <summary>
        /// Получить название колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        string GetColumnHeaderName(int index);
        /// <summary>
        /// Получить тип колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        FlexiColumnType GetColumnType(int index);
        /// <summary>
        /// Получить ширину колонки
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        /// <returns></returns>
        int GetColumnWidth(int index);
        /// <summary>
        /// Удалить колонку
        /// </summary>
        /// <param name="index">Индекс 0..Count-1 в коллекции</param>
        void RemoveColumn(int index);

    }
}