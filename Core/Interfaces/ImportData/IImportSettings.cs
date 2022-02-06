using System.Collections.Generic;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Import settings 
    /// </summary>
    public interface IImportSettings : IBase
    {
        /// <summary>
        /// Import type
        /// </summary>
        CoaImportDataTypes Type { get; set; } 
        /// <summary>
        /// Data source path
        /// </summary>
        string DataSource { get; set; }
        /// <summary>
        /// Field mappings collection
        /// </summary>
        IFieldMappings FieldMappings { get; }
        /// <summary>
        /// Import folder settings colleciton
        /// </summary>
        IImportFolderSettings FolderSettings { get; }
        /// <summary>
        /// Use SQL query to import
        /// </summary>
        bool UseSql { get; set; }
        /// <summary>
        /// SQL statement to perfom import
        /// </summary>
        string SqlStatement { get; set; }
        /// <summary>
        /// Identifier fields
        /// </summary>
        IList<string> IdentifyFields { get; }
        /// <summary>
        /// Is logging import process
        /// </summary>
        bool Logging { get; set; }
        /// <summary>
        /// Log file prefix
        /// </summary>
        string LogPrefix { get; set; }
        /// <summary>
        /// Folder store log files
        /// </summary>
        string LogFolder { get; set; }        
    }
}