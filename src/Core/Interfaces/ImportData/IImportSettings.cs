using System.Collections.Generic;
using FlexiObject.Core.Enumes;

namespace FlexiObject.Core.Interfaces
{
    /// <summary>
    /// Настройка импорта данных
    /// </summary>
    public interface IImportSettings : IBase
    {
        /// <summary>
        /// Тип импорта данных
        /// </summary>
        FlexiImportDataTypes Type { get; set; } 
        /// <summary>
        /// Источник данных
        /// </summary>
        string DataSource { get; set; }
        /// <summary>
        /// 
        /// </summary>
        IFieldMappings FieldMappings { get; }
        /// <summary>
        /// Настройки импорта данных
        /// </summary>
        IImportFolderSettings FolderSettings { get; }
        /// <summary>
        /// Использовать SQL запрос
        /// </summary>
        bool UseSql { get; set; }
        /// <summary>
        /// Использовать SQL 
        /// </summary>
        string SqlStatement { get; set; }
        /// <summary>
        /// Поля-идентификаторы
        /// </summary>
        List<string> IdentifyFields { get; }
        /// <summary>
        /// Логирование данных
        /// </summary>
        bool Logging { get; set; }
        /// <summary>
        /// Префикс файла логирования
        /// </summary>
        string LogPrefix { get; set; }
        /// <summary>
        /// Папка логирования импорта
        /// </summary>
        string LogFolder { get; set; }        
    }
}