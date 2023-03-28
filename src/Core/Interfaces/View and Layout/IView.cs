namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Объект представляет отображение объектов папки.
    /// Содержит фильтр и визуальное представление
    /// </summary>
    public interface IView : IBase
    {
        /// <summary>
        /// Описание
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Фильтр
        /// </summary>
        IFilter Filter { get; set; }
        /// <summary>
        /// Вывод данных
        /// </summary>
        IViewLayout Layout { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Открытое или скрытое представление
        /// </summary>
        bool Public { get; set; }
        /// <summary>
        /// Уникальный ид представления
        /// </summary>
        int UniqueId { get; }
        /// <summary>
        /// Правило видимости
        /// </summary>
        IRule VisibilityRule { get; set; }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        /// <param name="overwrite">Перезаписать при наличии объекта в базе</param>
        void Save(bool overwrite = false);
    }
}