namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Иинтерфейс доступа к индексу правила
    /// </summary>
    public interface IFilterFieldIndexer
    {
        /// <summary>
        /// Доступ к значению правила по имени
        /// </summary>
        /// <param name="name">Имя поля</param>
        /// <returns>Поле</returns>
        object this[string name] { get; set; }
    }
}