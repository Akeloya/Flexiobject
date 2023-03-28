namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Значение выпадающего списка
    /// </summary>
    public interface IDropDownValue : IBase
    {
        /// <summary>
        /// Алиас выпадающего значения
        /// </summary>
        string Alias { get; set; } 
        /// <summary>
        /// Описание выпадающего значение
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Название выпадающего значения
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Уровень, определяющий порядок в коллекции
        /// </summary>
        int Level { get; }
        /// <summary>
        /// Предшественник
        /// </summary>
        IDropDownValue Predecessor { get; }
        /// <summary>
        /// Преемник
        /// </summary>
        IDropDownValue Successor { get; }
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        int UniqueId { get; }
    }
}