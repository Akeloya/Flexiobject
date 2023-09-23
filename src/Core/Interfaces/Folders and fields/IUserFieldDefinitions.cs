using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция определений пользовательскиъ полей
    /// </summary>
    public interface IUserFieldDefinitions : IBase
    {
        /// <summary>
        /// Доступ к определению опльзовательских полей по индексу
        /// </summary>
        /// <param name="idx">Индекс 0..Count-1 коллекции определения пользовательских полей</param>
        /// <returns>IUserFieldDefinition объект</returns>
        IUserFieldDefinition this[int idx] { get; }
        /// <summary>
        /// Количество определений пользовательских полей в коллекции
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Добавление нового определения пользовательского поля
        /// </summary>
        /// <param name="type">Тип пользовательского поля</param>
        /// <returns>IUserFieldDefinition объект нового определения</returns>
        IUserFieldDefinition Add(FlexiFieldTypes type);
        /// <summary>
        /// Удалить определение пользовательского поля по индексу или алиасу
        /// </summary>
        /// <param name="variant">Индекс или алиас пользовательского поля</param>
        void Delete(object variant);
        /// <summary>
        /// Добавить пользовательское поле в коллекции
        /// </summary>
        /// <param name="field">Определение пользовательского поля</param>
        void AddExisting(IUserFieldDefinition field);
        /// <summary>
        /// Удаление поля из коллекции без удаления из БД.
        /// Метод может быть вызван только если объект используется в качестве контейнера
        /// </summary>
        /// <seealso cref="IsContainer"/>
        /// <param name="field"></param>
        void RemoveExisting(IUserFieldDefinition field);
        /// <summary>
        /// Флаг, обозначающий является ли текущий объект контейнером контейнером или нет.
        /// Если объект является контейнером, невозможно использовать методы Add, Delete
        /// Если объект не является контейнером, то невозможно использовать методы AddExisting, RemoveExisting
        /// </summary>
        bool IsContainer { get; }
        /// <summary>
        /// Доступ к коллекции определений полей по алиасу
        /// </summary>
        /// <param name="alias">Алиас определения пользовательского поля</param>
        /// <returns>IUserFieldDefinition определение пользовательского поля</returns>
        IUserFieldDefinition this[string alias] { get; }
    }
}