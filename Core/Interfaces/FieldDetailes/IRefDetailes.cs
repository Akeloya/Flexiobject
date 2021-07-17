using System.ComponentModel;

namespace CoaApp.Core.Interfaces
{
    /// <summary>
    /// Settings of field with reference to ICustomObject and ICustomObjects
    /// <see cref="IUserFieldDefinition"/>
    /// <seealso cref="ICustomObject"/>
    /// <seealso cref="ICustomObjects"/>
    /// </summary>
    public interface IRefDetailes : IBase
    {
        /// <summary>
        /// Cascade copy objects in field references
        /// </summary>
        bool CascadeCopy { get; set; }
        /// <summary>
        /// Cascade delete objects in field references
        /// </summary>
        bool CascadeDelete { get; set; }
        /// <summary>
        /// Default folder for selecting object if there are many folders 
        /// </summary>
        ICustomFolder DefaultFolder { get; set; }
        /// <summary>
        /// Script to implement algorythm selecting default folder
        /// </summary>
        IScript DefaultFolderScript { get; set; }
        /// <summary>
        /// Flag to use script to select default folder
        /// </summary>
        bool DefaultFolderUseScript { get; set; }
        /// <summary>
        /// Quick select field for easy selection of a value
        /// </summary>
        IUserFieldDefinition QuickSearchField { get; set; }
        /// <summary>
        /// Flag to delete referenced objects
        /// </summary>
        bool DeleteRefObjects { get; set; }
        /// <summary>
        /// Including subfolders during selecting objects
        /// </summary>
        bool IncludeSubfolders { get; set; }
        /// <summary>
        /// Syncrfonize field with
        /// </summary>
        bool IsSynchronized { get; set; }
        /// <summary>
        /// Master field in non symmetric syncronization
        /// </summary>
        bool MasterField { get; set; }
        /// <summary>
        /// Referenced folder (folder which stored objects)
        /// </summary>
        ICustomFolder ReferencedFolder { get; set; }
        /// <summary>
        /// Restriction filter flag
        /// </summary>
        bool Restriction { get; set; }
        /// <summary>
        /// Restriction flag will be work only for selecting objects
        /// </summary>
        bool RestrictionOnlyForSelection { get; set; }
        /// <summary>
        /// Restriction error message for user
        /// </summary>
        string RestrictionOptionalErrorMessage { get; set; }
        /// <summary>
        /// Restriction script
        /// </summary>
        IScript RestrictionScript { get; set; }
        /// <summary>
        /// Restriction rule
        /// </summary>
        IRule RestrictionRule { get; set; }
        /// <summary>
        /// Flag marks to execute restriction script instead calculating rule
        /// </summary>
        bool RestrictionUseScript { get; set; }
        /// <summary>
        /// Symmetric synchronization flag.
        /// </summary>
        bool SymmetricSynchronization { get; set; }
        /// <summary>
        /// User field syncronization for symmetric syncronization
        /// </summary>
        IUserFieldDefinition SynchronizedField { get; set; }
        /// <summary>
        /// User fields syncronization for asymmetric syncronization
        /// </summary>
        IUserFieldDefinitions SynchronizedFields { get; set; }
        /// <summary>
        /// Get default folder
        /// </summary>
        /// <returns></returns>
        ICustomFolder GetDefaultFolder();
        /// <summary>
        /// Get restriction filter
        /// </summary>
        /// <returns></returns>
        IFilter GetRestrictionFilter();
    }
}