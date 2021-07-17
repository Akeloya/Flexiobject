using System;
using System.Collections.Generic;
using System.ComponentModel;
using CoaApp.Core.Enumes;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Script (scenario) - executable c# code
    /// </summary>
    public interface IScript : IBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Script identifier
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Script description
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Script name
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// c# code
        /// </summary>
        string Script { get; set; }
        /// <summary>
        /// Script type
        /// </summary>
        CoaScriptTypes Type { get; set; }
        /// <summary>
        /// Reference to app object (form)
        /// </summary>
        int Reference { get; }
        /// <summary>
        /// Build state flag
        /// </summary>
        bool Builded { get; }
        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns>Errors after build on save</returns>
        IEnumerable<string> Save();
        /// <summary>
        /// Build script
        /// </summary>
        /// <returns>Errors after build</returns>
        IEnumerable<string> Build();
        /// <summary>
        /// Publish new version into application
        /// </summary>
        /// <returns>Errors on publish. If errors not empty - publish failed.</returns>
        IEnumerable<string> Publish();
        /// <summary>
        /// Last build time
        /// </summary>
        DateTime? BuildedTime { get;}     
        /// <summary>
        /// Active build errors
        /// </summary>
        IEnumerable<string> Errors { get; }
        /// <summary>
        /// Script folder
        /// </summary>
        ICustomFolder Folder { get; }
        /// <summary>
        /// Script history changes
        /// </summary>
        IScriptHistoryItems HistoryItems { get; }
    }
}