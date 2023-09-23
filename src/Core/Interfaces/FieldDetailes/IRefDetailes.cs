using System.ComponentModel;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Дополнительная информация поля типа объект и список объектов
    /// </summary>
    public interface IRefDetailes : IBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Флаг операции каскадного копирования
        /// </summary>
        bool CascadeCopyOperations { get; set; }
        /// <summary>
        /// Индикатор операции каскадного удаление объектов
        /// </summary>
        bool CascadeDeleteOperations { get; set; }
        /// <summary>
        /// Папка по умолчанию, необходима при работе с дочерними объектами
        /// </summary>
        ICustomFolder DefaultFolder { get; set; }
        /// <summary>
        /// Скрипт папки по умолчанию
        /// </summary>
        IScript DefaultFolderScript { get; set; }
        /// <summary>
        /// Флаг использования скрипта для папки по умолчанию
        /// </summary>
        bool DefaultFolderUseScript { get; set; }
        /// <summary>
        /// Поле быстрого поиска объекта
        /// </summary>
        IUserFieldDefinition DefaultQuickSearchField { get; set; }
        /// <summary>
        /// Индикатор удаления ссылок на объект
        /// </summary>
        bool DeleteRefObjects { get; set; }
        /// <summary>
        /// Включение подпапок
        /// </summary>
        bool IncludeSubfolders { get; set; }
        /// <summary>
        /// Синхронизировано ли поле
        /// </summary>
        bool IsSynchronized { get; set; }
        /// <summary>
        /// Индикатор мастер-поля синхронизации
        /// </summary>
        bool MasterField { get; set; }
        /// <summary>
        /// Папка, связанная с полем
        /// </summary>
        ICustomFolder ReferencedFolder { get; set; }
        /// <summary>
        /// Флак идентифицирующий использование фильтра ограничения
        /// </summary>
        bool Restriction { get; set; }
        /// <summary>
        /// Флаг идентифицирующий ограничения только для выбранного объекта
        /// </summary>
        bool RestrictionOnlyForSelection { get; set; }
        /// <summary>
        /// Ошибка, выдаваемая пользователю при нарушении ограничения
        /// </summary>
        string RestrictionOptionalErrorMessage { get; set; }
        /// <summary>
        /// Сприкт ограничения
        /// </summary>
        IScript RestrictionScript { get; set; }
        /// <summary>
        /// Правило ограничения
        /// </summary>
        IRule RestrictionRule { get; set; }
        /// <summary>
        /// Флаг использования скрипта ограничения
        /// </summary>
        bool RestrictionUseScript { get; set; }
        /// <summary>
        /// Флаг симметричной синхронизации полей
        /// </summary>
        bool SymmetricSynchronization { get; set; }
        /// <summary>
        /// Поле синхронизации
        /// </summary>
        IUserFieldDefinition SynchronizedField { get; set; }
        /// <summary>
        /// Поля синхонизации
        /// </summary>
        IUserFieldDefinitions SynchronizedFields { get; set; }
        /// <summary>
        /// Получить папку по-умолчанию
        /// </summary>
        /// <returns></returns>
        ICustomFolder GetDefaultFolder();
        /// <summary>
        /// Получить фильтр ограничения на связанные объекты
        /// </summary>
        /// <returns></returns>
        IFilter GetRestrictionFilter();
    }
}