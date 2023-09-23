namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Детали поля выпадающего списка
    /// </summary>
    public interface IDropDownListDetailes : IBase
    {
        /// <summary>
        /// Количество элементов коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Значение по-умолчанию
        /// </summary>
        IDropDownValue DefaultValue { get; set; }
        /// <summary>
        /// Наивысшее значение
        /// </summary>
        IDropDownValue Highest { get; }
        /// <summary>
        /// Низшее значение
        /// </summary>
        IDropDownValue Lowest { get; }
        /// <summary>
        /// Доступ к коллекции по индексу
        /// </summary>
        /// <param name="idx">0..Count-1</param>
        /// <returns></returns>
        IDropDownValue this[int idx] { get; }
        /// <summary>
        /// Доступ к элементу коллекции по алиасу
        /// </summary>
        /// <param name="alias">строка-алиас элемента</param>
        /// <returns></returns>
        IDropDownValue this[string alias] { get; }
        /// <summary>
        /// Создание нового элемента коллекции. Для добавления в коллекцию используется InsertAt
        /// </summary>
        /// <returns>IDropDownValue объект</returns>
        IDropDownValue CreateDropDownValue();
        /// <summary>
        /// Добавление созданного IDropDownValue объекта в коллекцию
        /// </summary>
        /// <param name="val">IDropDownValue добавляемый объект</param>
        /// <param name="idx">0...Count-1 индекс места вставки</param>
        void InsertAt(IDropDownValue val, int idx);
        /// <summary>
        /// Удаление элемента коллекции по индексу
        /// </summary>
        /// <param name="idx">0..Count-1 индекс удаляемого элемента</param>
        void Remove(int idx);
        /// <summary>
        /// Смена мест двух элементов коллекции
        /// </summary>
        /// <param name="idx1">0...Count-1</param>
        /// <param name="idx2">0...Count-1</param>
        void Swap(int idx1, int idx2);
    }
}