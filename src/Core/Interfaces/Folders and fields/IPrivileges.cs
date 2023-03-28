namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Коллекция разрешений для папки
    /// </summary>
    public interface IPrivileges : IBase
    {
        /// <summary>
        /// Создать новое разрешение. Изменения применятся после сохранения объекта.
        /// <see cref="IPrivilege.Save"/>
        /// </summary>
        /// <returns>Объект IPermission</returns>
        IPrivilege Add();
        /// <summary>
        /// Удаление записи из коллекции по индексу
        /// </summary>
        /// <param name="index">0..Count-1 индекс</param>
        void Remove(int index);
        /// <summary>
        /// Удаление записи из коллекции. Запись должна принадлежать коллекции
        /// </summary>
        /// <param name="obj">Удаляемый объект <see cref="IPrivilege"/></param>
        void Remove(IPrivilege obj);
        /// <summary>
        /// Количество привелегий
        /// </summary>
        int Count { get; }
        /// <summary>
        /// Получение привелегии по индексу
        /// </summary>
        /// <param name="index">0...Count-1 значение индекса</param>
        /// <returns>Объект <see cref="IPrivilege"/></returns>
        IPrivilege this[int index] { get; }
    }
}
