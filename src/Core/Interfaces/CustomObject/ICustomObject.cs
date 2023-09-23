using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Обсновной объект приложения
    /// </summary>
    public interface ICustomObject : IBase
    {
        /// <summary>
        /// Уникальный идентификатор объекта
        /// </summary>
        long UniqueId { get; }
        /// <summary>
        /// Название объекта, формируемое из схемы
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Пользовательские поля объекта
        /// </summary>
        IUserFields UserFields { get; }
        /// <summary>
        /// История изменения объекта
        /// </summary>
        IHistory History { get; }
        /// <summary>
        /// Сохранение объекта
        /// </summary>
        void Save();//TODO:модифицировать метод для передачи флага правила сохранения объекта, чтобы отключать модификации, калькуляции и т.д.
        /// <summary>
        /// Удаление объекта
        /// </summary>
        /// <param name="skipTrashbin">Пропустить при удалении корзину</param>
        /// <param name="ignoreReferences">Проигнорировать ссылки при удалении</param>
        /// <param name="flags">Параметры удаления объекта</param>
        /// <returns></returns>
        void Delete(bool skipTrashbin = false, bool ignoreReferences = false, FlexiDeletionObjectFlags? flags = null);
        /// <summary>
        /// Родительская папка объекта
        /// </summary>
        ICustomFolder RequestFolder { get; }
        /// <summary>
        /// Получение состояние модификации объекта
        /// </summary>
        bool IsModified { get; }
    }
}