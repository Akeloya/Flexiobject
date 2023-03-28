namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция объектов
    /// </summary>
    public interface ICustomObjects : IBaseCollection<ICustomObject>
    {
        /// <summary>
        /// Добавить существующий объект в коллекцию
        /// </summary>
        /// <param name="request">Добавляемый объект</param>
        void AddExisting(ICustomObject request);
        /// <summary>
        /// Добавить существующийо бъект по идентификатору
        /// </summary>
        /// <param name="id">Ид объекта</param>
        void AddExistingById(long id);
        /// <summary>
        /// Удаление связи с существующим объектом
        /// </summary>
        /// <param name="variant">Удаляемый IRequest объект или индекс в списке объектов</param>
        void RemoveExisting(object variant);
        /// <summary>
        /// Удаление существующего объекта по ИД
        /// </summary>
        /// <param name="id">ИД удаляемого объекта</param>
        void RemoveExistingById(long id);
        /// <summary>
        /// Восстановить объект
        /// </summary>
        /// <param name="id">Ид восстанавливаемого объекта</param>
        /// <returns></returns>
        void Restore(long id);
        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="id">Ид удаляемого объекта</param>
        /// <returns></returns>
        void Delete(long id);
    }
}