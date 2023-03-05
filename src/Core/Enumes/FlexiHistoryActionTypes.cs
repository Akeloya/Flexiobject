namespace FlexiObject.Core.Enumes
{
    /// <summary>
    /// Коллекция типов записей истории изменения объектов
    /// </summary>
    public enum FlexiHistoryActionTypes
    {
        /// <summary>
        /// Объект создан
        /// </summary>
        ObjCreated = 1,
        /// <summary>
        /// Удаление объекта
        /// </summary>
        ObjDeleted,
        /// <summary>
        /// Object was restored from trashbin
        /// </summary>
        ObjRestored,
        /// <summary>
        /// Object was copied
        /// </summary>
        ObjCopied,
        /// <summary>
        /// Изменено пользовательское поле
        /// </summary>
        FieldModified,
        /// <summary>
        /// Изменен список объектов
        /// </summary>
        ModifyObjectLIst,
        /// <summary>
        /// Перемещение вложения
        /// </summary>
        AttachmentMoved,
        /// <summary>
        /// Добавление ссылки
        /// </summary>
        ReferenceAdded,
        /// <summary>
        /// Удаление ссылки
        /// </summary>
        ReferenceRemoved,
        /// <summary>
        /// Добавлено вложение
        /// </summary>
        AttachmentAdded,
        /// <summary>
        /// Вложение удалено
        /// </summary>
        AttachmentDeleted,
        /// <summary>
        /// Изменение вложения
        /// </summary>
        AttachmentModified,
        /// <summary>
        /// Изменение описания вложения
        /// </summary>
        AttachmentDescriptionModified,
        /// <summary>
        /// Создание схемы импорта
        /// </summary>
        CreatedSchemaImport
    }
}